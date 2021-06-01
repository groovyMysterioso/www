using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using www.Data;
using www.Models;

namespace www.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }
        [HttpGet]
        public  string GetUserPostsRss(long UserID)
        {
            var User = _context.Users.Find(UserID);
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://jamespritts.com"), "FeedID", DateTime.Now);
            // Add a custom attribute.
            XmlQualifiedName xqName = new XmlQualifiedName("GameBeOkKey");
            feed.AttributeExtensions.Add(xqName, "codeHard1");

            SyndicationPerson sp = new SyndicationPerson(User.Email, User.UserName, $"http://jamespritts.com/u/{User.UserName}");
            feed.Authors.Add(sp);

            SyndicationCategory category = new SyndicationCategory("FeedCategory", "CategoryScheme", "CategoryLabel");
            feed.Categories.Add(category);

            feed.Contributors.Add(new SyndicationPerson("james.pritts@gmail.com", "James Pritts", "http://jamespritts.com"));
            feed.Copyright = new TextSyndicationContent($"Copyright {DateTime.Now.Year}");
            feed.Description = new TextSyndicationContent("Personal Post Feed");

            // Add a custom element.
            XmlDocument doc = new XmlDocument();
            XmlElement feedElement = doc.CreateElement("CustomElement");
            feedElement.InnerText = "Some text";
            feed.ElementExtensions.Add(feedElement);

            feed.Generator = "GameBeOk User Rss Feed";
            feed.Id = "FeedID";
            feed.ImageUrl = new Uri("http://server/image.jpg");

            var userPosts = _context.Posts.Where(x => x.Sender == User.Email);

            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach(var v in userPosts)
            {

            TextSyndicationContent textContent = new TextSyndicationContent(v.Content);
            SyndicationItem item = new SyndicationItem("User Post", textContent, new Uri("http://server/items"), "ItemID", DateTime.Now);

            items.Add(item);
            }

            feed.Items = items;
            feed.Language = "en-us";
            feed.LastUpdatedTime = DateTime.Now;

            SyndicationLink link = new SyndicationLink(new Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000);
            feed.Links.Add(link);

            XmlWriter atomWriter = XmlWriter.Create("atom.xml");
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
            atomFormatter.WriteTo(atomWriter);
            atomWriter.Close();

            using (XmlWriter rssWriter = XmlWriter.Create("rss.xml"))
            {

                Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(feed);
                rssFormatter.WriteTo(rssWriter);
                 return rssWriter.ToString();
            }

        }
        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(string id)
        {
            var Post = await _context.Posts.FindAsync(id);

            if (Post == null)
            {
                return NotFound();
            }

            return Post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(string id, Post Post)
        {
            if (id != Post.Id)
            {
                return BadRequest();
            }

            _context.Entry(Post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post Post)
        {
            _context.Posts.Add(Post);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostExists(Post.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPost", new { id = Post.Id }, Post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            var Post = await _context.Posts.FindAsync(id);
            if (Post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(Post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(string id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
