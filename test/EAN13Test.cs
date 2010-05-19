using NUnit.Framework;

[TestFixture]
public class EAN13Test
{
  [Test]
  public void SumMethod()
  {
    Assert.AreEqual(5, EAN13.sum(3, 2));
  }

  [Test]
  public void CalcCheckDigitMethod()
  {
    Assert.AreEqual("5", EAN13.calc_check_digit("978033042362"));
    Assert.AreEqual("0", EAN13.calc_check_digit("978174237257"));

    Assert.IsNull(EAN13.calc_check_digit(""));
    Assert.IsNull(EAN13.calc_check_digit("9780330423625"));
  }

  [Test]
  public void CompleteMethod()
  {
    Assert.AreEqual("9780330423625", EAN13.complete("978033042362"));
    Assert.AreEqual("9781742372570", EAN13.complete("978174237257"));

    Assert.AreEqual("9780330423625", EAN13.complete("9780330423625"));
    Assert.AreEqual("James", EAN13.complete("James"));
  }

  [Test]
  public void ValidMethod()
  {
    Assert.IsTrue(EAN13.valid("9780330423625"));
    Assert.IsFalse(EAN13.valid("9780330423626"));
    Assert.IsFalse(EAN13.valid("978033042362"));
    Assert.IsFalse(EAN13.valid("James"));
  }

  [Test]
  public void BooklandMethod()
  {
    Assert.IsTrue(EAN13.bookland("9780330423625"));
    Assert.IsFalse(EAN13.bookland("9780330423626"));
    Assert.IsFalse(EAN13.bookland("978033042362"));
    Assert.IsFalse(EAN13.bookland("James"));
    Assert.IsFalse(EAN13.bookland("9311181111364"));
  }

  [Test]
  public void ToUpcMethod()
  {
    Assert.IsNull(EAN13.to_upc("9780330423625"));
    Assert.IsNull(EAN13.to_upc("James"));

    Assert.AreEqual("768371090623", EAN13.to_upc("0768371090623"));
  }
}

