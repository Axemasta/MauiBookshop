using System;
namespace Bookshop.Behaviors;

// https://github.com/VladislavAntonyuk/MauiSamples/blob/main/MauiImageEffects/BlurBehavior/BlurBehavior.cs
public partial class BlurBehavior
{
	public static readonly BindableProperty RadiusProperty = BindableProperty.Create(nameof(Radius), typeof(float), typeof(BlurBehavior), 10f, propertyChanged: OnRadiusChanged);

	public float Radius
	{
		get => (float)GetValue(RadiusProperty);
		set => SetValue(RadiusProperty, value);
	}

	private static void OnRadiusChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var behavior = (BlurBehavior)bindable;
		if (behavior.imageView is null)
		{
			return;
		}

		behavior.SetRendererEffect(behavior.imageView, Convert.ToSingle(newValue));
	}
}
