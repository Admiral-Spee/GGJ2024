Shader "Unlit/Slider"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Back("Back",2D)="white"{}
        _Fill("Full",2D)="white"{}
        _Alpha("_Alpha",2D)="white"{}
        _Value("_Value",float)=0
    }
    SubShader
    {
        Tags{"RenderType"="Opaque"}
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _Back;
            sampler2D _Fill;
            sampler2D _Alpha;
            float _Value;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                fixed thread=tex2D(_Alpha,i.uv);

                fixed4 col1;
                fixed4 col2;
                if(thread.r<_Value)
                    col1=tex2D(_Fill,i.uv);
                else
                    col1=tex2D(_Back,i.uv);
                // apply fog
                return col1;
                // return col;
            }
            ENDCG
        }
    }
}