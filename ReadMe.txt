HtmlUI

Build the app with:
  nmake all

In order to save download time, I've excluded the mshtml.dll interop 
assembly from the zip. Use:
  nmake run
to generate the interop assembly and run the app.

You will require the Platform SDK, along with the .NET Framework SDK,
in order to be able to rebuild the app.

Nikhil Dabas, ndabas@hotmail.com