using Godot;
using System;
using System.Diagnostics;

public class TextureRect2 : Godot.TextureRect
{
    HTTPClient http = null;
    
    public override void _Ready()
    {
        //string host = "192.168.1.9";

        //Error err;
        //http = new HTTPClient();
        //err = http.ConnectToHost(host, 8887);
        //Debug.Assert(err == Error.Ok); // Make sure the connection is OK.

        //while (http.GetStatus() == HTTPClient.Status.Connecting || http.GetStatus() == HTTPClient.Status.Resolving)
        //{
        //    // Connecting...

        //    http.Poll();
        //    OS.DelayMsec(500);
        //}

        //Debug.Assert(http.GetStatus() == HTTPClient.Status.Connected);

        ////http.Request(HTTPClient.Method.Get, "/video", null);
        ////Debug.Assert(err == Error.Ok); // Make sure all is OK.

        ////while (http.GetStatus() == HTTPClient.Status.Requesting)
        ////{
        ////    // Requesting...

        ////    http.Poll();
        ////    OS.DelayMsec(500);
        ////}

        ////Debug.Assert(http.GetStatus() == HTTPClient.Status.Body || http.GetStatus() == HTTPClient.Status.Connected); // Make sure the request finished well.
    }
    
    public override void _Process(float delta)
    {
        //http.Request(HTTPClient.Method.Get, "/video", null);
        //while (http.GetStatus() == HTTPClient.Status.Requesting)
        //{
        //    // Requesting...
        //    http.Poll();
        //}
        
        //if (http.HasResponse())
        //{
        //    if (http.GetStatus() == HTTPClient.Status.Body)
        //    {
        //        var image = new Image();
                
        //        var buf = http.ReadResponseBodyChunk();
        //        var error = image.LoadJpgFromBuffer(buf);
        //        if (error != Error.Ok)
        //            GD.PushError("Couldn't load the image.");

        //        var texture = new ImageTexture();
        //        texture.CreateFromImage(image);

        //        this.Texture = texture;

        //        http.Poll();
        //    }
        //}
    }
}
