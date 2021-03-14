#version 330 core
in struct VertexOut
{
	vec2 Position;
	vec2 Uv;
} o;

uniform sampler2D Main;
out vec4 glFragColor;

void main()
{
	float sample = texture(Main, o.Uv).r;

    float scale = 1.0 / fwidth(sample);
    float signedDistance = (sample - 0.5) * scale;

    float color = clamp(signedDistance + 0.5, 0.0, 1.0);
    float alpha = clamp(signedDistance + 0.5 + scale * 0.125, 0.0, 1.0);
    glFragColor = vec4(color, color, color, 1) * alpha;
}