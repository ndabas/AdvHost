all : bin\HtmlUI.exe

run : bin\HtmlUI.exe
  bin\HtmlUI.exe

bin\AxSHDocVw.dll : $(SYSTEMROOT)\system32\SHDocVw.dll
  aximp $(SYSTEMROOT)\System32\SHDocVw.dll /out:bin\AxSHDocVw.dll

bin\MSHTML.dll : $(SYSTEMROOT)\system32\MSHTML.tlb
  tlbimp MSHTML.tlb /out:bin\MSHTML.dll

bin\MsHtmHstInterop.dll : bin\MsHtmHstInterop.tlb
  tlbimp bin\MsHtmHstInterop.tlb /out:bin\MsHtmHstInterop.dll

bin\MsHtmHstInterop.tlb : MsHtmHstInterop.idl
  midl MsHtmHstInterop.idl /tlb bin\MsHtmHstInterop.tlb

HtmlUI.RES : HtmlUI.rc Sample1.htm
  rc HtmlUI.rc

bin\HtmlUI.exe : bin\MsHtmHstInterop.dll bin\AxSHDocVw.dll bin\MSHTML.dll HtmlUI.cs HtmlUI.RES
  csc /target:winexe /debug+ /warn:4 /r:bin\AxSHDocVw.dll /r:bin\MsHtmHstInterop.dll /r:bin\MSHTML.dll /out:bin\HtmlUI.exe /win32res:HtmlUI.RES HtmlUI.cs
  
clean:
  del /s *.exe *.pdb *.dll *.resources
