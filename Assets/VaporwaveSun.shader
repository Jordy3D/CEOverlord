// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-3771-OUT,clip-845-OUT;n:type:ShaderForge.SFN_Tex2d,id:4401,x:31725,y:32587,ptovrint:False,ptlb:node_4401,ptin:_node_4401,varname:node_4401,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:98fe74aab133ac34d8f186b325c4d8c8,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3037,x:31725,y:32761,ptovrint:False,ptlb:node_3037,ptin:_node_3037,varname:node_3037,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:398f0ce81c379a94ca64cedda360fe94,ntxv:3,isnm:False|UVIN-6422-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9544,x:31364,y:32636,varname:node_9544,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:2865,x:31161,y:32678,varname:node_2865,prsc:2;n:type:ShaderForge.SFN_Panner,id:6422,x:31554,y:32761,varname:node_6422,prsc:2,spu:0.1,spv:0.1|UVIN-9544-UVOUT,DIST-6186-OUT;n:type:ShaderForge.SFN_Slider,id:8322,x:30836,y:32808,ptovrint:False,ptlb:node_8322,ptin:_node_8322,varname:node_8322,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8116351,max:1;n:type:ShaderForge.SFN_RemapRange,id:2695,x:31161,y:32808,varname:node_2695,prsc:2,frmn:0,frmx:1,tomn:1,tomx:10|IN-8322-OUT;n:type:ShaderForge.SFN_Divide,id:6186,x:31364,y:32784,varname:node_6186,prsc:2|A-2865-TTR,B-2695-OUT;n:type:ShaderForge.SFN_Multiply,id:4183,x:32199,y:32580,varname:node_4183,prsc:2|A-4401-RGB,B-3037-RGB;n:type:ShaderForge.SFN_Tex2d,id:4058,x:31725,y:32947,ptovrint:False,ptlb:node_4058,ptin:_node_4058,varname:node_4058,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5d21a4aee64e87a4fb260e1415cf24f9,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1847,x:32057,y:32852,varname:node_1847,prsc:2|A-4401-A,B-3037-A;n:type:ShaderForge.SFN_Multiply,id:845,x:32247,y:32919,varname:node_845,prsc:2|A-1847-OUT,B-4058-A;n:type:ShaderForge.SFN_Multiply,id:3771,x:32422,y:32591,varname:node_3771,prsc:2|A-9597-RGB,B-4183-OUT;n:type:ShaderForge.SFN_Color,id:9597,x:31938,y:32425,ptovrint:False,ptlb:node_9597,ptin:_node_9597,varname:node_9597,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:1,c4:1;proporder:4401-3037-8322-4058-9597;pass:END;sub:END;*/

Shader "Shader Forge/VaporwaveSun" {
    Properties {
        _node_4401 ("node_4401", 2D) = "bump" {}
        _node_3037 ("node_3037", 2D) = "bump" {}
        _node_8322 ("node_8322", Range(0, 1)) = 0.8116351
        _node_4058 ("node_4058", 2D) = "bump" {}
        _node_9597 ("node_9597", Color) = (1,0,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_4401; uniform float4 _node_4401_ST;
            uniform sampler2D _node_3037; uniform float4 _node_3037_ST;
            uniform float _node_8322;
            uniform sampler2D _node_4058; uniform float4 _node_4058_ST;
            uniform float4 _node_9597;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_4401_var = tex2D(_node_4401,TRANSFORM_TEX(i.uv0, _node_4401));
                float4 node_2865 = _Time;
                float2 node_6422 = (i.uv0+(node_2865.a/(_node_8322*9.0+1.0))*float2(0.1,0.1));
                float4 _node_3037_var = tex2D(_node_3037,TRANSFORM_TEX(node_6422, _node_3037));
                float4 _node_4058_var = tex2D(_node_4058,TRANSFORM_TEX(i.uv0, _node_4058));
                clip(((_node_4401_var.a*_node_3037_var.a)*_node_4058_var.a) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (_node_9597.rgb*(_node_4401_var.rgb*_node_3037_var.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_4401; uniform float4 _node_4401_ST;
            uniform sampler2D _node_3037; uniform float4 _node_3037_ST;
            uniform float _node_8322;
            uniform sampler2D _node_4058; uniform float4 _node_4058_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_4401_var = tex2D(_node_4401,TRANSFORM_TEX(i.uv0, _node_4401));
                float4 node_2865 = _Time;
                float2 node_6422 = (i.uv0+(node_2865.a/(_node_8322*9.0+1.0))*float2(0.1,0.1));
                float4 _node_3037_var = tex2D(_node_3037,TRANSFORM_TEX(node_6422, _node_3037));
                float4 _node_4058_var = tex2D(_node_4058,TRANSFORM_TEX(i.uv0, _node_4058));
                clip(((_node_4401_var.a*_node_3037_var.a)*_node_4058_var.a) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
