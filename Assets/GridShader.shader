// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "GridShader"
{
	Properties
	{
		_Diffuse("Diffuse", 2D) = "white" {}
		[Toggle]_UseColour("Use Colour", Float) = 1
		_Colour("Colour", Color) = (0.3962264,0,0.2783396,0)
		_Emmissive("Emmissive", 2D) = "white" {}
		_Brightness("Brightness", Range( 0 , 5)) = 1.155214
		_Noise("Noise", 2D) = "white" {}
		_NoiseStrength("Noise Strength", Range( 0 , 5)) = 1.155214
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 4.6
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _NoiseStrength;
		uniform sampler2D _Noise;
		uniform float4 _Noise_ST;
		uniform half _UseColour;
		uniform sampler2D _Diffuse;
		uniform float4 _Diffuse_ST;
		uniform float4 _Colour;
		uniform float _Brightness;
		uniform sampler2D _Emmissive;
		uniform float4 _Emmissive_ST;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 uv_Noise = v.texcoord * _Noise_ST.xy + _Noise_ST.zw;
			float2 appendResult23 = (float2(0.0 , ( _NoiseStrength * tex2Dlod( _Noise, float4( uv_Noise, 0, 0.0) ) ).r));
			v.vertex.xyz += float3( appendResult23 ,  0.0 );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Diffuse = i.uv_texcoord * _Diffuse_ST.xy + _Diffuse_ST.zw;
			o.Albedo = lerp(tex2D( _Diffuse, uv_Diffuse ),_Colour,_UseColour).rgb;
			float2 uv_Emmissive = i.uv_texcoord * _Emmissive_ST.xy + _Emmissive_ST.zw;
			o.Emission = ( _Brightness * tex2D( _Emmissive, uv_Emmissive ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15600
528;419;970;614;1627.726;261.9393;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;8;-655.1837,58.33698;Float;False;Property;_NoiseStrength;Noise Strength;6;0;Create;True;0;0;False;0;1.155214;1.24;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;7;-672.1349,136.8869;Float;True;Property;_Noise;Noise;5;0;Create;True;0;0;False;0;bd70d478b65e1dc43b8caeb2e73a72f6;cd460ee4ac5c1e746b7a734cc7cc64dd;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;5;-554.751,-502.6177;Float;False;Property;_Colour;Colour;2;0;Create;True;0;0;False;0;0.3962264,0,0.2783396,0;0.3962264,0,0.2783396,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-834.0145,-199.7455;Float;True;Property;_Emmissive;Emmissive;3;0;Create;True;0;0;False;0;bd70d478b65e1dc43b8caeb2e73a72f6;bd70d478b65e1dc43b8caeb2e73a72f6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-365.3007,56.31126;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;2;-820.9427,-284.053;Float;False;Property;_Brightness;Brightness;4;0;Create;True;0;0;False;0;1.155214;1.59;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;24;-636.0302,-700.8885;Float;True;Property;_Diffuse;Diffuse;0;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ToggleSwitchNode;25;-259.9913,-455.1112;Half;False;Property;_UseColour;Use Colour;1;0;Create;True;0;0;False;0;1;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-374.1425,-274.3533;Float;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;23;-208.0659,58.94861;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-3.900001,-266.4999;Float;False;True;6;Float;ASEMaterialInspector;0;0;Standard;GridShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;42.1;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;7;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;9;0;8;0
WireConnection;9;1;7;0
WireConnection;25;0;24;0
WireConnection;25;1;5;0
WireConnection;3;0;2;0
WireConnection;3;1;1;0
WireConnection;23;1;9;0
WireConnection;0;0;25;0
WireConnection;0;2;3;0
WireConnection;0;11;23;0
ASEEND*/
//CHKSM=5DCF210966EFF1F76ED998E98A8613A05F7B2D5D