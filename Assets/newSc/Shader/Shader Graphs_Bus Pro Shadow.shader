Shader "Shader Graphs/Bus Pro Shadow" {
	Properties {
		[NoScaleOffset] _MainTex ("Texture2D", 2D) = "white" {}
		_ambiant_str ("ambiant str", Range(0, 3)) = 0
		_light_str ("light str", Range(0, 2)) = 0
		_spec_str ("spec str", Range(0, 1)) = 1
		_specular ("specular", Range(0, 1)) = 0
		_spec_smooth ("spec smooth", Float) = 0
		_light_clamp ("light clamp", Range(0, 1)) = 0.34
		_light_smooth ("light smooth", Range(0, 1)) = 0
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
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
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
}