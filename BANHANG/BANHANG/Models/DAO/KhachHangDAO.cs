using BANHANG.Models.EF;
using BANHANG.Models.VIEW;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BANHANG.Models.DAO
{
    public class KhachHangDAO
    {
        private BANHANGContext context = new BANHANGContext();
        public void InsertOrUpdate(KhachHang item)
        {
            if (item.Id == 0)
            {
                context.KhachHangs.Add(item);
            }
            context.SaveChanges();
        }
        public KhachHang getItem(int id)
        {
            return context.KhachHangs.Where(x => x.Id == id).FirstOrDefault();   
        
        }
        public KhachHangVIEW getItemView(int id)
        {
            var query = (from a in context.KhachHangs                     
                         where a.Id == id&& a.Status=="active"
                         select new KhachHangVIEW
                         {
                            Id=a.Id,
                            Name=a.Name,
                            Birthday=a.Birthday.Value,
                            Sdt=a.Sdt,
                            Address=a.Address,
                            Img=a.Img,
                            Username=a.Username,
                            Password=a.Password,
                            Status=a.Status
                         }).FirstOrDefault();
          
            return query;
        }
        public List<KhachHangVIEW> Search(out int total, string name = "", int index = 1, int size = 10)
        {
            if (name == null) name = "";
        
            var query = (from a in context.KhachHangs
                         where a.Name.Contains(name)  
                         select new KhachHangVIEW
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Birthday = a.Birthday.Value,
                             Sdt = a.Sdt,
                             Address = a.Address,
                             Img = a.Img,
                             Username = a.Username,
                             Password = a.Password,
                             Status = a.Status
                         });
            total = query.Count();

            var resultList = query.Skip((index - 1) * size).Take(size).ToList();

            return resultList;
        }

        public void Detele(int id)
        {
            KhachHang x = getItem(id);
            context.KhachHangs.Remove(x);
            context.SaveChanges();
        }
    }
}
