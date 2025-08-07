Shader "Custom/DissolveShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "gray" {}
        _DissolveAmount ("Dissolve Amount", Range(0,1)) = 0.0
        _EdgeColor ("Edge Color", Color) = (1, 0.5, 0, 1)
        _EdgeWidth ("Edge Width", Range(0.01, 0.2)) = 0.05
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off

        CGPROGRAM
        #pragma surface surf Lambert alpha

        sampler2D _MainTex;
        sampler2D _NoiseTex;
        float _DissolveAmount;
        float4 _EdgeColor;
        float _EdgeWidth;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            float4 tex = tex2D(_MainTex, IN.uv_MainTex);
            float noise = tex2D(_NoiseTex, IN.uv_MainTex).r;

            // Dissolve logic
            float edge = _DissolveAmount;
            float diff = noise - edge;

            // Vùng viền glow
            float edgeAlpha = smoothstep(0, _EdgeWidth, diff);
            float glow = 1.0 - edgeAlpha;

            // Hiển thị glow ở viền tan biến
            o.Albedo = tex.rgb * edgeAlpha + _EdgeColor.rgb * glow;
            o.Alpha = edgeAlpha;
            o.Emission = _EdgeColor.rgb * glow;
        }
        ENDCG
    }

    FallBack "Transparent/Diffuse"
}
