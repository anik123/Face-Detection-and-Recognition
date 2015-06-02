using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetection
{
    public partial class DisplayUserWiseImage : Form
    {
        DbTransaction transaction = new DbTransaction();
        List<User> UserInfoList = new List<User>();
        public DisplayUserWiseImage()
        {
            InitializeComponent();
        }

        private void DisplayUserWiseImage_Load(object sender, EventArgs e)
        {
            
            loadUsers();
            loadUserInfo();
        }

        private void loadUsers()
        {
            cmbUser.DataSource = transaction.getAllUsers();
            cmbUser.DisplayMember = "FullName";
            cmbUser.ValueMember = "UserID";
            //cmbUser.Items.Insert(0,new object(){});
        }

        private void loadUserInfo()
        {
            UserInfoList = transaction.fetechImage();
            lblFaceCount.Text ="Total "+ UserInfoList.Count() + " faces";
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var imgList = UserInfoList.Where(o => o.UserID == int.Parse(cmbUser.SelectedValue.ToString()));
            if (imgList.Any())
            {
                int count = 0;
                foreach (var img in imgList)
                {
                    if (count == 0)
                    {
                        picBox1.Image = new Bitmap(ImageDecompress(img.Image), new Size(128, 128));
                        count++;
                    }
                    else if (count == 1)
                    {
                        picBox2.Image = new Bitmap(ImageDecompress(img.Image),new Size(128,128));
                        count++;
                    }
                    else if (count == 2)
                    {
                        picBox3.Image = new Bitmap(ImageDecompress(img.Image), new Size(128, 128));
                        count++;
                    }
                }
            }
        }
        private Image ImageDecompress(byte[] imgByte)
        {
            try
            {
                var stream = new MemoryStream(imgByte);
                var img = Image.FromStream(stream);
                return img;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
