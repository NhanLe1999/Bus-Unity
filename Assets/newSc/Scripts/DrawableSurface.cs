using UnityEngine;
using UnityEngine.EventSystems;

public class DrawableSurface : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler
{
	public Camera camera;

	[SerializeField]
	private Texture2D brushTex;

	private RenderTexture dirtMask;

	[SerializeField]
	private Texture2D dirtTex;

	[SerializeField]
	private Mesh meshToDraw;

	public Renderer rend;

	[SerializeField]
	private bool isAutoBake;

	private float[,] brushBaked;

	private float[,] dirtBaked;

	private int offsetX;

	private int offsetY;

	private float dirtMaskWidth;

	private float dirtMaskHeight;

	private float brushWidth;

	private float brudhHeight;

	private int boundX;

	private int boundY;

	private float timePoint;

	[SerializeField]
	private bool isCheck;

	[SerializeField]
	private bool isDrawOnDrag;

	[SerializeField]
	private float checkDelay;

	[SerializeField]
	private Material blitMat;

	[SerializeField]
	private float maxBrushDistOnDragPercent;

	private float maxDragDist;

	private Vector2 lastPos;

	private bool isSetLAstPos;

	private Vector2 curCoord;

	private Vector2 lastCoord;

	private static readonly int MainTex;

	private static readonly int BrushWidth;

	private static readonly int BrushHeight;

	private static readonly int DirtWidth;

	private static readonly int DirtHeight;

	private static readonly int Pos;

	private const string MAIN_TEX = "_MainTex";

	private const string BLIT_DIRT_WIDTH = "_DirtWidth";

	private const string BLIT_DIRT_HEIGHT = "_DirtHeight";

	private const string BLIT_BRUSH_WIDTH = "_BrushWidth";

	private const string BLIT_BRUSH_HEIGHT = "_BrushHeight";

	private const string BLIT_POS = "_Pos";

	private static readonly int GLOBAL_PIXEL_COUNT;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}

	protected virtual void OnCompleteDraw()
	{
	}

	protected virtual void OnDrawCheckFail()
	{
	}

	public void StartCheck()
	{
	}

	public void SetUpBake(Texture2D tex)
	{
	}

	[ContextMenu("Bake")]
	private void Bake()
	{
	}

	private void DrawToTEx()
	{
	}

	private static bool AABBContainsSegment(float x1, float y1, float x2, float y2, float minX, float minY, float maxX, float maxY, out Vector2 coord)
	{
		coord = default(Vector2);
		return false;
	}

	private void ExecuteDraw(Vector2 textureCoord)
	{
	}

	private bool CheckDone()
	{
		return false;
	}
}
