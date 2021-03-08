#version 330 core

layout(location = 0) in vec3 Position;
layout(location = 1) in vec3 Normal;
layout(location = 2) in vec4 Color;
layout(location = 3) in vec2 Uv;

out struct VertexOut
{
	vec3 Position;
	vec3 Normal;
	vec4 Color;
	vec2 Uv;
} o;

uniform mat4 MODEL,VIEW,PROJ,OTHRO;

vec4 ObjectToWorld(vec3 v)
{
	return PROJ * VIEW * MODEL * vec4(v,1);
}

void main()
{
	gl_Position = ObjectToWorld(Position);
	o.Position = Position;
	o.Normal = Normal;
	o.Color = Color;
	o.Uv = Uv;
}