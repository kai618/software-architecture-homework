using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShared
{
    public interface IVideoBUS
    {
        List<Video> GetAll();

        List<Video> Search(string keyword, string attribute);

        bool Add(Video video);

        bool Update(Video video);

        bool Delete(int id);
    }
}