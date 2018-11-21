// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "DoorGemShader"
{
	Properties
	{
		_DoorTexture1("DoorTexture (1)", 2D) = "white" {}
		_Brightness("Brightness", Range( 0 , 1)) = 1
		_GemGlow("GemGlow", Range( 0 , 1)) = 1
		[Toggle]_ToggleSwitch0("Toggle Switch0", Float) = 1
		_Color1("Color 1", Color) = (0,1,0,0)
		_Color0("Color 0", Color) = (1,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _ToggleSwitch0;
		uniform sampler2D _DoorTexture1;
		uniform float4 _DoorTexture1_ST;
		uniform float4 _Color0;
		uniform float4 _Color1;
		uniform float _GemGlow;
		uniform float _Brightness;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_DoorTexture1 = i.uv_texcoord * _DoorTexture1_ST.xy + _DoorTexture1_ST.zw;
			float4 lerpResult6 = lerp( _Color0 , _Color1 , _GemGlow);
			o.Emission = ( lerp(tex2D( _DoorTexture1, uv_DoorTexture1 ),lerpResult6,_ToggleSwitch0) * _Brightness ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15600
144;264;1293;697;1658.173;387.8078;1.346766;True;False
Node;AmplifyShaderEditor.ColorNode;5;-958.7012,7.508467;Float;False;Property;_Color1;Color 1;4;0;Create;True;0;0;False;0;0,1,0,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;4;-957.048,-155.9031;Float;False;Property;_Color0;Color 0;5;0;Create;True;0;0;False;0;1,0,0,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;2;-1027.088,171.4681;Float;False;Property;_GemGlow;GemGlow;2;0;Create;True;0;0;False;0;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-717.5,-281.5;Float;True;Property;_DoorTexture1;DoorTexture (1);0;0;Create;True;0;0;False;0;676047bbd90808142930208ca539e285;676047bbd90808142930208ca539e285;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;6;-657.0076,-84.71738;Float;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-446.2406,126.5547;Float;False;Property;_Brightness;Brightness;1;0;Create;True;0;0;False;0;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;3;-393.1935,-95.49999;Float;True;Property;_ToggleSwitch0;Toggle Switch0;3;0;Create;True;0;0;False;0;1;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-137.4609,-90.80985;Float;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;136.4078,29.23024;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;DoorGemShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;6;0;4;0
WireConnection;6;1;5;0
WireConnection;6;2;2;0
WireConnection;3;0;1;0
WireConnection;3;1;6;0
WireConnection;8;0;3;0
WireConnection;8;1;7;0
WireConnection;0;2;8;0
ASEEND*/
//CHKSM=D57ACE03883CE68E460FD18EB5DB0943C3C7522B