using CodeBase.Model;

namespace CodeBase.Presenters
{
    public class CirclePresenter : GearPresenter<Circle>
    {
        protected override void OnConstructed()
        {
            transform.localScale = transform.localScale * 2 * (float)Model.Radius.Magnitude;
        }
    }
}