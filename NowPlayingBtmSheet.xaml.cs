using System.Diagnostics;
using UraniumUI.Material.Attachments;

namespace SampleBuggingProj;

public partial class NowPlayingBtmSheet : BottomSheetView // added as transient service in mauiprogram.cs because if it's singleton then it will throw an exception
{
	public NowPlayingBtmSheet()
	{
		InitializeComponent();
	}

    protected override void OnOpened()
    {
        
            base.OnOpened();
            Debug.WriteLine("Opened==============");
            this.Header.HeightRequest = 490; // (3) adding this to fix (2) but it will cause the issue observed in the first video
            this.BorderToShowWhenBtmSheetOpens.HeightRequest = 490;
            VSLToShowWhenBtmSheetCloses.IsVisible = false;
            BorderToShowWhenBtmSheetOpens.IsVisible = true;
            

            this.HeightRequest = this.AttachedPage.Height;
            Shell.SetNavBarIsVisible(this.AttachedPage, false);
            Shell.SetTabBarIsVisible(this.AttachedPage, true);
            Debug.WriteLine($"BtmSheet Height {this.Height}");
            Debug.WriteLine($"BtmSheet header Height {this.Header.Height}");
            Debug.WriteLine($"BtmSheet body Height {this.Body.Height}");
            Debug.WriteLine($"BtmSheet body content Height just to be thorough {this.VSLContent.Height}");
            Debug.WriteLine($"BtmSheet header top part Height {this.VSLToShowWhenBtmSheetCloses.Height}");
            Debug.WriteLine($"BtmSheet header bottom part Height {this.BorderToShowWhenBtmSheetOpens.Height}"); 
        
    }

    protected override void OnClosed()
    {
        
            base.OnClosed();

            this.BorderToShowWhenBtmSheetOpens.HeightRequest = 0;
            this.Body.HeightRequest = 0;  //(1) setting this
            this.Header.HeightRequest = 62; //and this will force to a fixed size on close
            //(2) but the issue is that the body and header will overlap since height request is 62


            //this.HeightRequest = 200; // (4) setting this hoping to fix (3) and only the header will be shown but NOTHING shows anymore when you open and close. it shows only on first boot
            
            Debug.WriteLine("Closed==============");
            VSLToShowWhenBtmSheetCloses.IsVisible = true;
            BorderToShowWhenBtmSheetOpens.IsVisible = false;

            Shell.SetNavBarIsVisible(this.AttachedPage, false);
            Shell.SetTabBarIsVisible(this.AttachedPage, true);


            Debug.WriteLine($"BtmSheet Height {this.Height}");
            Debug.WriteLine($"BtmSheet header Height {this.Header.Height}");
            Debug.WriteLine($"BtmSheet body Height {this.Body.Height}");
            Debug.WriteLine($"BtmSheet body content Height just to be thorough {this.VSLContent.Height}");
            Debug.WriteLine($"BtmSheet header top part Height {this.VSLToShowWhenBtmSheetCloses.Height}");
            Debug.WriteLine($"BtmSheet header bottom part Height {this.BorderToShowWhenBtmSheetOpens.Height}"); //this will not be = 0, though it was set to be
        
    }
}