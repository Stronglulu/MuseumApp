Shader "Unlit/UnlitAlpha"
{
	Properties
	{
		_Color ("Main Color (A=Opacity)", Color) = (1,1,1,1)
		_MainTex ("Base (A=Opacity)", 2D) = ""
	}

	Category {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True"}
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
 
    SubShader {Pass {
        GLSLPROGRAM
        varying mediump vec2 uv;
       
        #ifdef VERTEX
        uniform mediump vec4 _MainTex_ST;
        void main() {
            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
            uv = gl_MultiTexCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
        }
        #endif
       
        #ifdef FRAGMENT
        uniform lowp sampler2D _MainTex;
        uniform lowp vec4 _Color;
        void main() {
            gl_FragColor = texture2D(_MainTex, uv) * _Color;
        }
        #endif     
        ENDGLSL
    }}
   
    SubShader {Pass {
        SetTexture[_MainTex] {Combine texture * constant ConstantColor[_Color]}
    }}
}
 


	SubShader
	{
		Tags { "RenderType"="Opaque" }
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
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
