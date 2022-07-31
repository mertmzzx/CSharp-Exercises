using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void TestDummyLoosesHealthAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(0), "Dummy's health doesn't change after attack.");
        }

        [Test]
        public void TestDeadDummyThrowsExceptionWhenAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>((() => axe.Attack(dummy)));
        }

        [Test]
        public void TestDeadDummyCanGiveExp()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(10);

            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(10));
        }

        [Test]
        public void TestAliveDummyCantGiveExp()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(1);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}