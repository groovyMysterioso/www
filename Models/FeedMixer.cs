using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class FeedMixer 
    {
        public float Leftism;
        public float Liberatarianism;
        public Feed LiberalRss;
        public Feed ConservativeRss;
        public Feed AuthoritarianRss;
        public Feed LibertarianRss;
        public FeedMixer()
        {
            Leftism = 0.5f;
            Liberatarianism = 0.5f;
        }
    }
}
