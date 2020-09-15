using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Codisa.Application.Models.Empleado;
using Codisa.Core.Entities;
using Codisa.Infrastructure.ParamsDTO;
using Codisa.Infrastructure.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Codisa.Application.Controllers
{
    public class EmpleadoController : Controller
    {
        #region ATTRIBUTES
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IEmpleadoHabilidadRepository _empleadoHabilidadRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public EmpleadoController(IMapper mapper, IEmpleadoRepository empleadoRepository, IAreaRepository areaRepository, 
            IEmpleadoHabilidadRepository empleadoHabilidadRepository)
        {
            _empleadoRepository = empleadoRepository ?? throw new ArgumentNullException(nameof(empleadoRepository));
            _areaRepository = areaRepository ?? throw new ArgumentNullException(nameof(areaRepository));
            _empleadoHabilidadRepository = empleadoHabilidadRepository ?? throw new ArgumentNullException(nameof(empleadoHabilidadRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region "METODOS"
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IList<EmpleadoDto>>(await _empleadoRepository.GetAllEmployee()));
        }

        [HttpGet]
        public async Task<IActionResult> NewEmployee()
        {
            var model = new CreateEmployee { };
            ViewBag.Areas = new SelectList(await _areaRepository.GetAllAreas(), "IdArea", "Nombre");
            return View("NewEmployee", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveEmployee(CreateEmployee createEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _empleadoRepository.CreateEmployee(_mapper.Map<Empleado>(createEmployee));
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception)
            {
                return BadRequest();
            }

            return View("NewEmployee", createEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(UpdateEmployee updateEmployee)
        {
            ViewBag.Areas = new SelectList(await _areaRepository.GetAllAreas(), "IdArea", "Nombre");
            return View("EditEmployee", updateEmployee);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveUpdateEmployee(UpdateEmployee updateEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _empleadoRepository.UpdateEmployee(_mapper.Map<Empleado>(updateEmployee));
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception)
            {
                return BadRequest();
            }

            return View("EditEmployee", updateEmployee);
        }

        [HttpGet]
        public async Task <IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _empleadoRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DetailEmployee(EmpleadoDto empleadoDto)
        {
           return View(empleadoDto);
        }

        [HttpGet]
        public async Task<ActionResult> DetailSkill(int id, string nombre)
        {
            try
            {
                if (!string.IsNullOrEmpty(id.ToString())  && !string.IsNullOrEmpty(nombre))
                {
                    HttpContext.Session.SetString("NombreEmpleado", nombre);
                    HttpContext.Session.SetInt32("IdEmpleado", id);
                    ViewBag.NombreEmpleado = HttpContext.Session.GetString("NombreEmpleado");
                }

                return View(_mapper.Map<IList<EmpleadoHabilidadDto>>(await _empleadoHabilidadRepository.GetAllEmployeeSkill(HttpContext.Session.GetInt32("IdEmpleado").Value)));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public IActionResult NewEmployeeSkill()
        {
            var model = new CreateEmployeeSkill {
                IdEmpleado = HttpContext.Session.GetInt32("IdEmpleado").Value
            };
            return View("NewEmployeeSkill", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveEmployeeSkill(CreateEmployeeSkill createEmployeeSkill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _empleadoHabilidadRepository.CreateEmployeeSkill(_mapper.Map<EmpleadoHabilidad>(createEmployeeSkill));
                    return RedirectToAction(nameof(DetailSkill));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return View("NewEmployeeSkill", createEmployeeSkill);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteEmployeeSkill(int id)
        {
            try
            {
                await _empleadoHabilidadRepository.DeleteEmployeeSkill(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("DetailSkill");
        }
        #endregion
    }
}