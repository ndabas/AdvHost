namespace NikhilDabas.HtmlUI
{
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    // JScript naming conventions here
    
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHtmlUIScript
    {
        [DispId(0)]
        void notify();
    }
    
    [ClassInterface(ClassInterfaceType.None)]
    class ScriptHelper : IHtmlUIScript // 80131531
    {
        public ScriptHelper()
        {
            
        }
        
        public void notify()
        {
            MessageBox.Show("Script alert!");
        }
    }
}