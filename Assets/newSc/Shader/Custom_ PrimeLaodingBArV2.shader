Shader "Custom/ PrimeLaodingBArV2" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_SubTex ("Sub Tex", 2D) = "white" {}
		_Float ("Float", Range(0, 1)) = 0
		_Offset ("Offset", Range(0.01, 0.2)) = 0.052
		_Stretch ("Stretch", Range(0.5, 1.5)) = 0
		_Speed ("Speed", Float) = 0.1
		_SubStretch ("SubStretch", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}