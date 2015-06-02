using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using FaceDetection.Data;

namespace FaceDetection
{
    public class DbTransaction
    {
        public void addFace(User user)
        {
            try
            {
                using (var entities = new FaceDBEntities())
                {
                    var entity = new EMUser().saveToDB(user);
                    entities.Users.Add(entity);
                    var count = entities.SaveChanges();
                    if (count > 0)
                    {
                        var userID = lastID();
                        foreach (var image in user.ImageList)
                        {
                            image.UserID = userID;
                            entities.UserImages.Add(new EMUser().saveToDB(image));
                        }
                        entities.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int lastID()
        {
            int count = 0;
            using (var entities = new FaceDBEntities())
            {
                count = entities.Users.OrderByDescending(o => o.UserID).First().UserID;
            }
            return count;
        }

        public List<User> fetechImage()
        {
            using (var entities = new FaceDBEntities())
            {
                var query = from user in entities.Users
                            join img in entities.UserImages on user.UserID equals img.UserID
                            select new { user, img };
                var result = (from o in query
                              select new User()
                              {
                                  UserID = o.user.UserID,
                                  FullName = o.user.FullName,
                                  Image = o.img.Images
                              }).ToList<User>();
                return result;
            }
        }

        public List<User> getAllUsers()
        {
            using (var entities = new FaceDBEntities())
            {
                var query = from user in entities.Users
                            select new { user };
                var result =
                    (from o in query select new User() { UserID = o.user.UserID, FullName = o.user.FullName })
                        .ToList<User>();
                return result;
            }
        }
    }
}
