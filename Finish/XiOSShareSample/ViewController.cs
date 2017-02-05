using System;
using System.IO;
using UIKit;

namespace XiOSShareSample
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewShareButton.TouchUpInside += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(FileData.FileName))
                {
                    var dir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    var file = Path.Combine(dir, "Inbox", FileData.FileName);
                    var text = File.ReadAllText(file);

                    ShareInfoLabel.Text = text;
                }
                else
                {
                    ShareInfoLabel.Text = "No shared file.";
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
