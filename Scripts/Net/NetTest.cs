using ProtoBuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class NetTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void click()
    {

        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        socket.Connect("192.168.4.95", 8080);
        print(11111111);

        NetModel item = new NetModel();
        item.ID = 3;
        item.Commit = "444";
        item.Message = "hahahah";

        byte[] temp = Serialize(item);
        Debug.Log(temp.Length);

        NetModel result = DeSerialize(temp);
        Debug.Log(result.Message);
    }


    private byte[] Serialize(NetModel model)
    {

        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<NetModel>(ms, model);
                byte[] result = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(result, 0, result.Length);
                return result;
            }
        }
        catch (Exception ex)
        {
            Debug.Log("序列化失败: " + ex.ToString());
            return null;
        }

    }


    private NetModel DeSerialize(byte[] msg)
    {

        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(msg, 0, msg.Length);
                ms.Position = 0;
                NetModel result = ProtoBuf.Serializer.Deserialize<NetModel>(ms);
                return result;
            }
        }

        catch (Exception ex)
        {
            Debug.Log("反序列化失败: " + ex.ToString());
            return null;
        }
    }
}
    [ProtoContract]
    public class NetModel
    { //添加特性，表示该字段可以被序列化，1可以理解为下标 [ProtoMember(1)] public int ID; [ProtoMember(2)] public string Commit; [ProtoMember(3)] public string Message; }

        [ProtoMember(1)]
        public int ID;

        [ProtoMember(2)]
        public string Commit;

        [ProtoMember(3)]
        public string Message;
    }