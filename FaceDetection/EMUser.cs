using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection
{
    public class EMUser
    {
        public Data.User saveToDB(User user)
        {
            var d_user = new Data.User()
            {
                FullName = user.FullName,
                //Image = user.Image
            };
            return d_user;
        }

        public Data.UserImage saveToDB(UserImage user)
        {
            var d_user = new Data.UserImage()
            {
                Images = user.Images,
                UserID = user.UserID
            };
            return d_user;
        }
    }

}
