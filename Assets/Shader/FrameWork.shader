Shader "XyShader/FrameWork"
{
    Properties//材质属性
    {

    }


    //子着色器,可以多,必须有一个
    SubShader
    {
        //具体的绘制,可以有多个
        pass
        {
            CGPROGRAM     
            //定义顶点着色器 name
            #pragma vertex vert 
            //定义片段着色器  name
            #pragma fragment frag
            //
            #include "UnityCG.cginc"
            //应用程序数据appdata 要加分号 appdata用struct结构来定义 内容是顶点的两个属性
            struct appdata
            {
                float4 vertex:POSITION;//POSITION语义 顶点位置属性
                float4 color:COLOR;//color顶点颜色信息


            };
            //顶点着色器到片元着色器 v2f是位置变量
            struct v2f
            {
                float4 pos:SV_POSITION;//位置 加sv是unity做不同平台的识别

            };



            //float 32位 位置 uv 高精度数据类型
            //half 16位-60000到60000 颜色 方向 法线
            //fixed-2到2  非hdr颜色0-1
            //integer 整形 
            //sampler2D sampler采样 2d贴图
            //samplerCUBE 3d贴图 6个面
            //float4 数据类型 4个float值

            //顶点着色器是个appdata结构
            //顶点着色器输出是v2f结构
            v2f vert(appdata v)//v是定义的名字
            {
                //float3 point =float3(1,10,5.6);
                //float4 pos1=float4(1,1,1,1);
                //float4 pos2=1;//4个数都是1可以这么写
                //float4 pos3=float4(point,1);

                //初始化
                v2f o =(v2f)0;
                //赋值
                //o.pos=v.vertex;
                //投影空间,世界空间
                //o.pos = mul(UNITY_MATRIX_VP,mul(unity_ObjectToWorld,v.vertex));
                //模型空间 直接到裁剪空间
                o.pos=UnityObjectToClipPos(v.vertex);


                //返回
                return o;


            }
            //v2f输入到片段着色器  定一个i
            //返回float4 颜色信息  语义是输入到屏幕的颜色 SV_TARGET
            float4 frag(v2f i):SV_TARGET
            {
                return 1;


            }








            ENDCG

        }

    }
    


}