using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WebSocketDemo : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Create WebSocket instance
        IWebSocket ws = WebSocketFactory.CreateInstance("ws://echo.websocket.org");

        // Add OnOpen event listener
        ws.OnOpen += () =>
        {
            Debug.Log("WS connected!");
            Debug.Log("WS state: " + ws.GetState().ToString());

            ws.Send(Encoding.UTF8.GetBytes("Hello from Unity 3D!"));
        };

        // Add OnMessage event listener
        ws.OnMessage += (byte[] msg) =>
        {
            Debug.Log("WS received message: " + Encoding.UTF8.GetString(msg));

            ws.Close();
        };

        // Add OnError event listener
        ws.OnError += (string errMsg) =>
        {
            Debug.Log("WS error: " + errMsg);
        };

        // Add OnClose event listener
        ws.OnClose += () =>
        {
            Debug.Log("WS closed.");
        };

        // Connect to the server
        ws.Connect();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}