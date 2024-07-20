using UnityEngine.Events;
using UnityEngine;

namespace EssentialToolkit.Pipelines
{
    public class InvokerPipeline : APipeline
    {
        [SerializeField]
        private UnityEvent onRun;

        public override void Run()
        {
            onRun.Invoke();
        }
    }
}