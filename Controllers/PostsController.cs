using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using www.Data;
using www.Models;
using www.Utilities;

namespace www.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt",".jpg" ,"mp4"};
        private readonly string _targetFilePath;

        public PostsController(ApplicationDbContext context, IConfiguration config, IHostingEnvironment env)
        {
            _env = env;
            _context = context;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");

            // To save physical files to a path provided by configuration:
            _targetFilePath = Path.Combine(_env.WebRootPath,config.GetValue<string>("StoredFilesPath"));

            // To save physical files to the temporary files folder, use:
            //_targetFilePath = Path.GetTempPath();
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posts.OrderBy(x => x.Created).ToListAsync());
        }
        // GET: Posts
        public async Task<IActionResult> IndexPartial()
        {
            return PartialView("ListIndex", await _context.Posts.OrderByDescending(x => x.Created).ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Post == null)
            {
                return NotFound();
            }

            return View(Post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        private IHostingEnvironment _env;
  

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Post Post, BufferedMultipleFileUploadPhysical FileUpload)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.Email); // will give the user's userId
                Post.User = userId;
                var attachedFiles = new List<string>();

                if(FileUpload.FormFiles!=null)
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
                    var trustedFileNameForFileStorage = Path.GetRandomFileName().Replace(".","")+formFile.FileName.Substring(formFile.FileName.Length-4);
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

                        // To work directly with the FormFiles, use the following
                        // instead:
                        //await formFile.CopyToAsync(fileStream);
                    }
                }
                Post.Attachments = string.Join(",", attachedFiles.ToArray());
                _context.Add(Post);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(Post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Post = await _context.Posts.FindAsync(id);
            if (Post == null)
            {
                return NotFound();
            }
            return View(Post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Content")] Post Post)
        {
            if (id != Post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(Post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(Post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Post == null)
            {
                return NotFound();
            }

            return View(Post);
        }
        // GET: Posts/Delete/5
        public async Task<IActionResult> DeletePartial(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Post == null)
            {
                return NotFound();
            }

            return PartialView("Delete",Post);
        }
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var Post = await _context.Posts.FindAsync(id);
            Post.isDeleted = true;
            _context.Posts.Update(Post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool PostExists(string id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }

        public class BufferedMultipleFileUploadPhysical
        {
            public BufferedMultipleFileUploadPhysical() { }

            public List<IFormFile> FormFiles { get; set; }

        }
    }
}
