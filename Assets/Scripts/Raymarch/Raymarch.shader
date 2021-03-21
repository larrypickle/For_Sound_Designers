Shader "Unlit/Raymarch"
{
    Properties
    {   _Color1 ("Color 1", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
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
         

            #include "UnityCG.cginc"

            // MEss with these so our game doesn't explode. Lower = better
            #define MAX_STEPS 100
            #define MAX_DIST 100
            #define SURF_DIST 1e-3
            //color
            uniform float3 _LightDir;
            // uniform fixed4 _mainColor;
            

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f //Modifys to use camera. Data structure gets sent to fragment shader
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 ro : TEXTCORD1; // Tells GPU where to render
                float3 hitPos : TEXTCORD2; 
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v) //Calculate to pass onto fragment shader
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                // o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.ro = _WorldSpaceCameraPos; //(Float4 turns it a fourth position, remove to make cool stuff) converts Worldspace to object space is relative to the world.
                o.hitPos = mul(unity_ObjectToWorld, v.vertex); // convert Object space to Worldspace ((Mess with this to figure out why camera is funky.))
                
                return o;
            }

            //Distance formula
            float GetDist(float3 p)
            {   
                float d = length(p % 1.5) - .5; // Grabs of the mesh distance. For sphere. (Note, increasing the number mod divides by makes it smaller but creates interesting shapes.)
                // d = length(float2(length(mod(p.xz, 1.0) - .5, p.y)) - .1;
                
                return d;
            }
            
            float Raymarch(float3 ro, float3 rd) //Raymarch function. Returns the depth
            {
                float dO = 14; //Distance origin to track of where it goes
                float dS; //Distance from scene/surface
                for(int i = 0; i < MAX_STEPS; i++) // Repeats till something is hit
                {
                    float3 p = ro + dO * rd;
                    float d = GetDist(p);
                    dS = GetDist(p);
                    dO += dS;
                    if(dS < SURF_DIST || dO > MAX_DIST) break; // Compares where the distance is and how far it goes

                    
                }   

                return dO;
            }

            float3 GetNormal(float3 p)
            {   float2 e = float2(1e-2, 0);
                float3 n = GetDist(p) - float3(GetDist(p-e.xyy), GetDist(p-e.yxy), GetDist(p-e.yyx));//Grabs vector distance of normals
                return normalize(n);
            }


            fixed4 frag (v2f i) : SV_Target
            {   
                float2 uv = i.uv - .5;
                float3 ro =  i.ro; //float3(0,0,-3); Hard coded position use for testing
                float3 rd = normalize(i.hitPos - ro); //normalize(float3(uv.x, uv.y, 1)); //Ray directions diverge
                
                float d = Raymarch(ro, rd);
                // sample the texture
               
                float3 col = float3(0,0,0);
                if(d < MAX_DIST)
                {   
                    float3 p = ro + rd * d;
                    float3 n = GetNormal(p);
                   
                    col.rgb = 0;
                }
                else
                {
                    discard; //Tells shader to not even render pixels. Makes mesh it's inside of fully transparent
                }
              
             

                return float4(col,1);
                
            }
            ENDCG
        }
    }
}
