using UnityEngine;

public class Parallax : MonoBehaviour
{
   private MeshRenderer meshRenderer;
   public float animationSpeed = 1f;

   private void Start()
   {
    meshRenderer = GetComponent<MeshRenderer>();
   }

   private void Update()
   {
     meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
   }
}
