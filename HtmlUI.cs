//
// HtmlUI
// 
// HtmlUI shows how to use the advanced hosting interfaces
// with a web browser control.
// 
// Nikhil Dabas, ndabas@hotmail.com
// 

namespace NikhilDabas.HtmlUI
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using MSHTML;
    using MsHtmHstInterop;
    using AxSHDocVw;
    
    [Serializable]
    public class HtmlUIForm : Form, IDocHostUIHandler
    {
        
        private System.ComponentModel.Container components = null;
        
        protected AxWebBrowser WebBrowser;
        
        public HtmlUIForm()
        {
            InitializeComponent();
            
            this.WebBrowser.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(this.WebBrowser_DocumentComplete);
            
            object flags = 0;
            object targetFrame = String.Empty;
            object postData = String.Empty;
            object headers = String.Empty;
            this.WebBrowser.Navigate("about:blank", ref flags, ref targetFrame, ref postData, ref headers);
            
            ICustomDoc cDoc = (ICustomDoc)this.WebBrowser.Document;
            cDoc.SetUIHandler((IDocHostUIHandler)this);
            
            this.WebBrowser.Navigate(@"res://HtmlUI.exe/Sample1.htm", ref flags, ref targetFrame, ref postData, ref headers);
        }
        
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }
        
        public void InitializeComponent()
        {
            this.WebBrowser = new AxWebBrowser();
            this.WebBrowser.BeginInit();
            this.SuspendLayout();
            
            this.Text = "HTML UI Demo";
            this.Size = new Size(563, 474);
            this.MinimumSize = new Size(563, 474);
            this.Font = new Font("Tahoma", 8);
            
            this.WebBrowser.Dock = DockStyle.Fill;
            
            this.Controls.Add(this.WebBrowser);
            this.ResumeLayout(false);
            this.WebBrowser.EndInit();
        }
        
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new HtmlUIForm());
        }
        
        private void WebBrowser_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
        {
            IHTMLDocument2 doc = (IHTMLDocument2)this.WebBrowser.Document;
            HTMLButtonElement button = (HTMLButtonElement)doc.all.item("theButton", null);
            ((HTMLButtonElementEvents2_Event)button).onclick += new HTMLButtonElementEvents2_onclickEventHandler(this.Button_onclick);
        }
        
        private bool Button_onclick(IHTMLEventObj e)
        {
            MessageBox.Show("Alert from the app: Received theButton.onclick!");
            return true;
        }
        
        // IDocHostUIHandler implementation
        
        void IDocHostUIHandler.EnableModeless(int fEnable)
        {
        
        }
        
        void IDocHostUIHandler.FilterDataObject(MsHtmHstInterop.IDataObject pDO, out MsHtmHstInterop.IDataObject ppDORet)
        {
            ppDORet = null;
        }
        
        void IDocHostUIHandler.GetDropTarget(IDropTarget pDropTarget, out IDropTarget ppDropTarget)
        {
            ppDropTarget = null;
        }
        
        void IDocHostUIHandler.GetExternal(out object ppDispatch)
        {
            ppDispatch = null;
        }
        
        void IDocHostUIHandler.GetHostInfo(ref _DOCHOSTUIINFO pInfo)
        {
            
        }
        
        void IDocHostUIHandler.GetOptionKeyPath(out string pchKey, uint dw)
        {
            pchKey = null;
        }
        
        void IDocHostUIHandler.HideUI()
        {
        
        }
        
        void IDocHostUIHandler.OnDocWindowActivate(int fActivate)
        {
        
        }
        
        void IDocHostUIHandler.OnFrameWindowActivate(int fActivate)
        {
        
        }
        
        void IDocHostUIHandler.ResizeBorder(ref MsHtmHstInterop.tagRECT prcBorder, IOleInPlaceUIWindow pUIWindow, int fRameWindow)
        {
        
        }
        
        void IDocHostUIHandler.ShowContextMenu(uint dwID, ref MsHtmHstInterop.tagPOINT ppt, object pcmdtReserved, object pdispReserved)
        {
            
        }
        
        void IDocHostUIHandler.ShowUI(uint dwID, IOleInPlaceActiveObject pActiveObject, IOleCommandTarget pCommandTarget, IOleInPlaceFrame pFrame, IOleInPlaceUIWindow pDoc)
        {
        
        }
        
        void IDocHostUIHandler.TranslateAccelerator(ref tagMSG lpmsg, ref Guid pguidCmdGroup, uint nCmdID)
        {
        
        }
        
        void IDocHostUIHandler.TranslateUrl(uint dwTranslate, ref ushort pchURLIn, IntPtr ppchURLOut)
        {
        
        }
        
        void IDocHostUIHandler.UpdateUI()
        {
        
        }
    }
}