using AutoFixture;
using AutoFixture.Xunit2;
using Booking.BLL.Models;

namespace Booking.BLL.Tests.Attributes;

public class AutoBookingData : AutoDataAttribute
{
    public AutoBookingData() : base(FixtureFactory)
    {
    }

    private static IFixture FixtureFactory()
    {
        var fixture = new Fixture();
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new ThrowingRecursionBehavior());

        fixture.Customize<BookingModel>(b => b.Without(x => x.Hotel));

        return fixture;
    }
}