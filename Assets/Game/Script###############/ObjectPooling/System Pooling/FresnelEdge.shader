Shader "Custom/FresnelEdge"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _FresnelColor ("Fresnel Color", Color) = (0.5, 0.8, 1, 1)
        _FresnelPower ("Fresnel Power", Range(0.1, 10)) = 2.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        float4 _FresnelColor;
        float _FresnelPower;

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            float4 tex = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = tex.rgb;

            // Tính toán Fresnel: càng vuông góc camera -> viền càng sáng
            float fresnel = pow(1.0 - saturate(dot(normalize(IN.viewDir), o.Normal)), _FresnelPower);
            o.Emission = _FresnelColor.rgb * fresnel;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
