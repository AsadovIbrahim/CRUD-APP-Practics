using Database.Entities.Concretes;
using Database.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Login_Register_Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        protected readonly ITeamRepository _teamRepository;
        protected readonly IWebHostEnvironment _webHostEnvironment;


        public MenuController(ITeamRepository teamRepository, IWebHostEnvironment webHostEnvironment)
        {
            _teamRepository = teamRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _teamRepository.GetAllAsync();
            return View(menus);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamUser teamUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string path = _webHostEnvironment.WebRootPath + @"\Upload\Menu\";
            string fileName = Guid.NewGuid() + teamUser.ImageFile.FileName;
            using (FileStream stream = new FileStream(path + fileName, FileMode.Create))
            {
                teamUser.ImageFile.CopyTo(stream);
            }
            teamUser.ImageUrl = fileName;

            await _teamRepository.AddAsync(teamUser);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _teamRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var existingItem = await _teamRepository.GetByIdAsync(id);
            return View(existingItem);
        }

        [HttpPost]

        public IActionResult Update(TeamUser teamUser)
        {
            if (!ModelState.IsValid) { return View(); }

            if (teamUser.ImageFile != null)
            {
                string path = _webHostEnvironment.WebRootPath + @"\Upload\Menu\";
                string fileName = Guid.NewGuid() + teamUser.ImageFile.FileName;
                string filePath = Path.Combine(path, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    teamUser.ImageFile.CopyTo(stream);
                }
                teamUser.ImageUrl = fileName;
            }
            _teamRepository.UpdateAsync(teamUser);
            return RedirectToAction("Index");
        }
    }
}
