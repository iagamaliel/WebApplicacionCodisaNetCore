using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Codisa.Application.Models.Area;
using Codisa.Core.Entities;
using Codisa.Infrastructure.ParamsDTO;
using Codisa.Infrastructure.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Codisa.Application.Controllers
{
    public class AreaController : Controller
    {
        #region ATTRIBUTES
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public AreaController(IMapper mapper, IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository ?? throw new ArgumentNullException(nameof(areaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region "METODOS"
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IList<AreaDto>>(await _areaRepository.GetAllAreas()));
        }

        [HttpGet]
        public IActionResult NewArea()
        {
            var model = new CreateArea { };
            return View("NewArea", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveArea(CreateArea createArea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _areaRepository.CreateArea(_mapper.Map<Area>(createArea));
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception)
            {
                return BadRequest();
            }

            return View("NewArea", createArea);
        }

        [HttpGet]
        public IActionResult EditArea(UpdateArea updateArea)
        {
            return View("EditArea", updateArea);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveUpdateArea(UpdateArea updateArea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _areaRepository.UpdateArea(_mapper.Map<Area>(updateArea));
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception)
            {
                return BadRequest();
            }

            return View("EditArea", updateArea);
        }

        [HttpGet]
        public ActionResult DeleteArea(int id)
        {
            try
            {
                _areaRepository.DeleteArea(id);
            } catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}