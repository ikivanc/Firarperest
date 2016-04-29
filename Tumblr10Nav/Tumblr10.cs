//using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumblr10Nav
{
    public class Photoset
    {
        public string ID { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Type { get; set; }        

     
        public class PhotosetList : List<Photoset>
        {
            public object Key { get; set; }
        }

        //Azure Mobile App which will be not used in this version of GitHub Project
        //private IMobileServiceTable<Photoset> photosetTable = App.MobileService.GetTable<Photoset>();
        //public async Task<List<Photoset>> getAllPhotosAMS()
        //{
        //    List<Photoset> pList = await photosetTable.Where(a => a.Country != null).ToListAsync();
        //    return pList;
        //}

        //public async Task<ObservableCollection<PhotosetList>> getByCountryGrouped()

        public ObservableCollection<PhotosetList> getByCountryGrouped()
        {
            ObservableCollection<PhotosetList> result = new ObservableCollection<PhotosetList>();         

            try
            {
                //Azure mobile apps query
                //var query = from photo in await photosetTable.Where(a => a.Country != null).ToListAsync()

                var query = from photo in getAllPhotos().Where(a => a.Country != null)
                            group photo by photo.Country into g
                            orderby g.Key
                            select new { GroupName = g.Key, Items = g };

                foreach (var g in query)
                {
                    PhotosetList info = new PhotosetList();
                    info.Key = g.GroupName;
                    foreach (var item in g.Items)
                    {
                        info.Add(item);
                    }
                    result.Add(info);
                }

                return result;
            }
            catch
            { 
                return result;
            }
        }
        public List<Photoset> getAllPhotos()
        {
            List<Photoset> photoList = new List<Photoset>();          
            photoList.Add(new Photoset { Thumbnail = "http://41.media.tumblr.com/9bba8a415d9ec9db5277d19c8d60bf2f/tumblr_ns2ls9SPrl1qg7dm4o5_500.jpg", Url = "http://ikivanc.tumblr.com/post/125042640234/urdun-amman-belki-de-buradaki-yakın", Title = "Jordan", Description = "", Country = "Jordan", City = "Amman", Longitude = 41.00, Latitude = 30.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://41.media.tumblr.com/f90f9abc09e5b8303636787654658446/tumblr_nir9jrfqPl1qg7dm4o2_500.jpg", Url = "http://ikivanc.tumblr.com/post/109147738454/aylarca-s&uuml;ren-iş-seyahati-temposundan-dolayı-son-6", Title = "London", Description = "", Country = "United Kingdom", City = "London", Longitude = 42.00, Latitude = 28.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/2c1e13b0d9e2e4c5152cbe5216d0f006/tumblr_nb36ojQE0o1qg7dm4o6_500.jpg", Url = "http://ikivanc.tumblr.com/post/96117958639/venedikte-bir-süre-kaldıktan-sonra-hızlı-tren-ile", Title = "Rome", Description = "", Country = "Italy", City = "Rome", Longitude = 42.00, Latitude = 42.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/988f46c536f364f7825b9b92d12b62a8/tumblr_n0ox1y056Q1qg7dm4o7_r1_500.jpg", Url = "http://ikivanc.tumblr.com/post/76020807776/venedik-gezisi-uzun-zaman-sonra-planladığım-ilk", Title = "Venice", Description = "", Country = "Italy", City = "Venice", Longitude = 42.00, Latitude = 26.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/7b286d1537fd553897477f8d448c47c3/tumblr_n0cccphMir1qg7dm4o1_500.jpg", Url = "http://ikivanc.tumblr.com/post/75304496243/daha-&ouml;nceden-almanyaya-varşova-u&ccedil;ağını", Title = "Munich", Description = "", Country = "Germany", City = "Munich", Longitude = 42.00, Latitude = 24.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://41.media.tumblr.com/89f8ac2ee217037c1c10d4acd6259a0d/tumblr_ns2mavHjNZ1qg7dm4o2_500.jpg", Url = "http://ikivanc.tumblr.com/post/125101282274/petra-jordan-ürdünün-güney-kısmında-akabeye-çok", Title = "Petra", Description = "", Country = "Jordan", City = "Petra", Longitude = 42.00, Latitude = 22.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://41.media.tumblr.com/9bba8a415d9ec9db5277d19c8d60bf2f/tumblr_ns2ls9SPrl1qg7dm4o5_500.jpg", Url = "http://ikivanc.tumblr.com/post/125042640234/urdun-amman-belki-de-buradaki-yakın", Title = "Jordan", Description = "", Country = "Jordan", City = "Amman", Longitude = 42.00, Latitude = 20.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://41.media.tumblr.com/f90f9abc09e5b8303636787654658446/tumblr_nir9jrfqPl1qg7dm4o2_500.jpg", Url = "http://ikivanc.tumblr.com/post/109147738454/aylarca-s&uuml;ren-iş-seyahati-temposundan-dolayı-son-6", Title = "London", Description = "", Country = "United Kingdom", City = "London", Longitude = 42.00, Latitude = 18.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/2c1e13b0d9e2e4c5152cbe5216d0f006/tumblr_nb36ojQE0o1qg7dm4o6_500.jpg", Url = "http://ikivanc.tumblr.com/post/96117958639/venedikte-bir-süre-kaldıktan-sonra-hızlı-tren-ile", Title = "Rome", Description = "", Country = "Italy", City = "Rome", Longitude = 41.00, Latitude = 42.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/988f46c536f364f7825b9b92d12b62a8/tumblr_n0ox1y056Q1qg7dm4o7_r1_500.jpg", Url = "http://ikivanc.tumblr.com/post/76020807776/venedik-gezisi-uzun-zaman-sonra-planladığım-ilk", Title = "Venice", Description = "", Country = "Italy", City = "Venice", Longitude = 39.00, Latitude = 42.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/7b286d1537fd553897477f8d448c47c3/tumblr_n0cccphMir1qg7dm4o1_500.jpg", Url = "http://ikivanc.tumblr.com/post/75304496243/daha-&ouml;nceden-almanyaya-varşova-u&ccedil;ağını", Title = "Munich", Description = "", Country = "Germany", City = "Munich", Longitude = 37.00, Latitude = 42.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://41.media.tumblr.com/89f8ac2ee217037c1c10d4acd6259a0d/tumblr_ns2mavHjNZ1qg7dm4o2_500.jpg", Url = "http://ikivanc.tumblr.com/post/125101282274/petra-jordan-ürdünün-güney-kısmında-akabeye-çok", Title = "Petra", Description = "", Country = "Jordan", City = "Petra", Longitude = 35.00, Latitude = 42.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://41.media.tumblr.com/9bba8a415d9ec9db5277d19c8d60bf2f/tumblr_ns2ls9SPrl1qg7dm4o5_500.jpg", Url = "http://ikivanc.tumblr.com/post/125042640234/urdun-amman-belki-de-buradaki-yakın", Title = "Jordan", Description = "", Country = "Jordan", City = "Amman", Longitude = 33.00, Latitude = 42.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://41.media.tumblr.com/f90f9abc09e5b8303636787654658446/tumblr_nir9jrfqPl1qg7dm4o2_500.jpg", Url = "http://ikivanc.tumblr.com/post/109147738454/aylarca-s&uuml;ren-iş-seyahati-temposundan-dolayı-son-6", Title = "London", Description = "", Country = "United Kingdom", City = "London", Longitude = 31.00, Latitude = 42.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/2c1e13b0d9e2e4c5152cbe5216d0f006/tumblr_nb36ojQE0o1qg7dm4o6_500.jpg", Url = "http://ikivanc.tumblr.com/post/96117958639/venedikte-bir-süre-kaldıktan-sonra-hızlı-tren-ile", Title = "Rome", Description = "", Country = "Italy", City = "Rome", Longitude = 31.00, Latitude = 31.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/988f46c536f364f7825b9b92d12b62a8/tumblr_n0ox1y056Q1qg7dm4o7_r1_500.jpg", Url = "http://ikivanc.tumblr.com/post/76020807776/venedik-gezisi-uzun-zaman-sonra-planladığım-ilk", Title = "Venice", Description = "", Country = "Italy", City = "Venice", Longitude = 29.00, Latitude = 29.00, Type = "Landscape" });
            photoList.Add(new Photoset { Thumbnail = "http://40.media.tumblr.com/7b286d1537fd553897477f8d448c47c3/tumblr_n0cccphMir1qg7dm4o1_500.jpg", Url = "http://ikivanc.tumblr.com/post/75304496243/daha-&ouml;nceden-almanyaya-varşova-u&ccedil;ağını", Title = "Munich", Description = "", Country = "Germany", City = "Munich", Longitude = 27.00, Latitude = 27.00, Type = "Landscape" });

            return photoList;
        }
        public List<Photoset> getByCity(string cityName)
        {
            List<Photoset> result = (from photo in getAllPhotos()
                                     where photo.City == cityName
                                     select photo).ToList<Photoset>();

            return result;
        }
    }
}

