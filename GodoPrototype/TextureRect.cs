using Godot;
using System;

public class TextureRect : Godot.TextureRect
{
    //HTTPClient client = null;

    //HTTPClient.Status status = default(HTTPClient.Status);
    //HTTPClient.Status current_status = default(HTTPClient.Status);


    public override void _Ready()
    {
        //string host = "192.168.1.9";
        //string response = "";


        //client = new HTTPClient();
        //var a = client.ConnectToHost(host, 8887);


        //while (true)
        //{
        //    client.Poll();
        //    current_status = client.GetStatus();
        //    if (status != current_status)
        //        status = current_status;

        //    if (status == HTTPClient.Status.Connected)
        //        break;
        //    else
        //        continue;
        //}

        //client.Request(HTTPClient.Method.Get, "/video", null);






        //client.Close();








        //var http_request = new HTTPRequest();
        //this.AddChild(http_request);
        //http_request.Connect("request_completed", this, "_http_request_completed");

        //var error = http_request.Request("http://192.168.1.9:8887/video");
        //if (error != Error.Ok)
        //    GD.PushError("An error occurred in the HTTP request.");
    }

    //void _http_request_completed(object result, object response_code, object headers, byte[] body)
    //{
    //    var image = new Image();
    //    var error = image.LoadJpgFromBuffer(body);
    //    if (error != Error.Ok)
    //        GD.PushError("Couldn't load the image.");

    //    var texture = new ImageTexture();
    //    texture.CreateFromImage(image);

    //    this.Texture = texture;
    //}

    //int i = 1;

    //long a3 = 0;
    public override void _Process(float delta)
    {
        //var a1 = DateTime.Now.Ticks;
        //if (a3 != 0)
        //{
        //    //GD.Print("p1 - " + i.ToString() + ": " + ((a1 - a3) / TimeSpan.TicksPerMillisecond).ToString());
        //}

        ////client.Poll();
        //current_status = client.GetStatus();
        //if (status != current_status)
        //    status = current_status;

        ////var a2 = DateTime.Now.Ticks;
        ////GD.Print("p2 - " + i.ToString() + ": " + ((a2 - a1) / TimeSpan.TicksPerMillisecond).ToString());

        //if (status == HTTPClient.Status.Body)
        //{
        //    //var image = new Image();

        //    //var error = image.LoadJpgFromBuffer(client.ReadResponseBodyChunk());
        //    //if (error != Error.Ok)
        //    //    GD.PushError("Couldn't load the image.");

        //    //var texture = new ImageTexture();
        //    //texture.CreateFromImage(image);

        //    //this.Texture = texture;







        //    //    //var b = client.IsResponseChunked();
        //    //    //var aa = client.GetResponseHeadersAsDictionary();
        //    //    //var chuns = client.ReadChunkSize;
        //    //    //var chunk = client.ReadResponseBodyChunk();
        //    //    //response = chunk.GetStringFromUTF8();

            




        //    //a3 = DateTime.Now.Ticks;
        //    //GD.Print("p3 - " + i.ToString() + ": " + ((a3 - a2) / TimeSpan.TicksPerMillisecond).ToString());

        //    //i++;
        //}
    }
}
