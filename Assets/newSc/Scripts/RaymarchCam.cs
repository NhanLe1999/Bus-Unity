using UnityEngine;
using UnityEngine.Rendering;

public class RaymarchCam : MonoBehaviour
{
	public Renderer rend;

	public Material raymarchMat;

	public new Transform transform;

	public Camera cam;

	public bool isRend;

	public Mesh mesh;

	public MeshFilter meshFilter;

	private static int CAM_FRUSTUM;

	private static int CAM_2_WORLD_MATRIX;

	private static int CAM_WORLD_SPACE;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnEndRender(ScriptableRenderContext context, Camera camera)
	{
	}

	private Matrix4x4 Camfrustum()
	{
		return default(Matrix4x4);
	}
}
