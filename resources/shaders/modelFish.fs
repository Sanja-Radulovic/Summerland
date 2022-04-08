#version 330 core
out vec4 FragColor;

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

uniform vec3 viewPos;
uniform vec3 lightPos;
uniform sampler2D diffuseTexture;


void main()
{
    vec3 color = texture(diffuseTexture, TexCoords).rgb;
    // ambient
    vec3 ambient = 0.7 * color;
    // diffuse
    vec3 lightDir = normalize(lightPos - FragPos);
    vec3 normal = normalize(Normal);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = diff * color;

    FragColor = vec4(ambient + diffuse + 0.0, 1.0);
}