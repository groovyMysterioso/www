using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using www.Data;
using www.Models;
using www.Utilities;
using static www.Controllers.PostsController;

namespace www.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt",".jpg" ,"mp4"};
        private readonly string _targetFilePath;
        private IHostingEnvironment _env;

        /*
         
          private readonly ApplicationDbContext _context;
        public PostsController(ApplicationDbContext context, IConfiguration config, IHostingEnvironment env)
        {
        }
         */
        public ProfilesController(ApplicationDbContext context, IConfiguration config, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");

            // To save physical files to a path provided by configuration:
            _targetFilePath = Path.Combine(_env.WebRootPath,config.GetValue<string>("StoredFilesPath"));

            // To save physical files to the temporary files folder, use:
            //_targetFilePath = Path.GetTempPath();
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profiles.ToListAsync());
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                var userId = User.FindFirstValue(ClaimTypes.Email); // will give the user's userId
                id = _context.Profiles.First(x => x.IdentityUser == userId).Id;
            }

            var profile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] Profile profile, BufferedMultipleFileUploadPhysical FileUpload)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.Email); // will give the user's userId
                profile.IdentityUser = userId;
                var attachedFiles = new List<string>();
                _context.Profiles.Where(x => x.IdentityUser == userId);
                if (FileUpload.FormFiles != null)
                    foreach (var formFile in FileUpload.FormFiles)
                    {
                        var formFileContent =
                            await FileHelpers
                                .ProcessFormFile<BufferedMultipleFileUploadPhysical>(
                                    formFile, ModelState, _permittedExtensions,
                                    _fileSizeLimit);

                        if (!ModelState.IsValid)
                        {
                            return View();
                        }

                        // For the file name of the uploaded file stored
                        // server-side, use Path.GetRandomFileName to generate a safe
                        // random file name.
                        var trustedFileNameForFileStorage = Path.GetRandomFileName().Replace(".", "") + formFile.FileName.Substring(formFile.FileName.Length - 4);
                        var filePath = Path.Combine(
                            _targetFilePath, trustedFileNameForFileStorage);
                        attachedFiles.Add(trustedFileNameForFileStorage);

                        // **WARNING!**
                        // In the following example, the file is saved without
                        // scanning the file's contents. In most production
                        // scenarios, an anti-virus/anti-malware scanner API
                        // is used on the file before making the file available
                        // for download or for use by other systems. 
                        // For more information, see the topic that accompanies 
                        // this sample.

                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            await fileStream.WriteAsync(formFileContent);
                            profile.ProfileImage = Path.Combine(
                            "PostedFiles", trustedFileNameForFileStorage);
                            // To work directly with the FormFiles, use the following
                            // instead:
                            //await formFile.CopyToAsync(fileStream);
                        }
                    }
                var PersonalPage = new Page();
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                var userId = User.FindFirstValue(ClaimTypes.Email); // will give the user's userId
                id = _context.Profiles.First(x => x.IdentityUser == userId).Id;
            }

            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ProfileImage,IdentityUser")] Profile profile,BufferedMultipleFileUploadPhysical FileUpload)
        {
            if (id == null)
            {
                var userId = User.FindFirstValue(ClaimTypes.Email); // will give the user's userId
                id = _context.Profiles.First(x => x.IdentityUser == userId).Id;
            }

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.Email); // will give the user's userId
                profile.IdentityUser = userId;
                var attachedFiles = new List<string>();
                _context.Profiles.Where(x => x.IdentityUser == userId);
                if (FileUpload.FormFiles != null)
                    foreach (var formFile in FileUpload.FormFiles)
                    {
                        var formFileContent =
                            await FileHelpers
                                .ProcessFormFile<BufferedMultipleFileUploadPhysical>(
                                    formFile, ModelState, _permittedExtensions,
                                    _fileSizeLimit);

                        if (!ModelState.IsValid)
                        {
                            return View();
                        }

                        // For the file name of the uploaded file stored
                        // server-side, use Path.GetRandomFileName to generate a safe
                        // random file name.
                        var trustedFileNameForFileStorage = Path.GetRandomFileName().Replace(".", "") + formFile.FileName.Substring(formFile.FileName.Length - 4);
                        var filePath = Path.Combine(
                            _targetFilePath, trustedFileNameForFileStorage);
                        attachedFiles.Add(trustedFileNameForFileStorage);

                        // **WARNING!**
                        // In the following example, the file is saved without
                        // scanning the file's contents. In most production
                        // scenarios, an anti-virus/anti-malware scanner API
                        // is used on the file before making the file available
                        // for download or for use by other systems. 
                        // For more information, see the topic that accompanies 
                        // this sample.
                        
                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            await fileStream.WriteAsync(formFileContent);
                            profile.ProfileImage = Path.Combine(
                            "PostedFiles", trustedFileNameForFileStorage);
                            // To work directly with the FormFiles, use the following
                            // instead:
                            //await formFile.CopyToAsync(fileStream);
                        }
                    }
                _context.Update(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
