const getType = (a) =>
  ({}).toString.call(a);

const mapObject = (a, f) =>
  Object.keys(a).map((key) => f(key, a[key]));

export const ofString = (String, Number, Object, Array, Boolean, Null, Some, None) => {
  const makeJson = (a) => {
    switch (getType(a)) {
    case "[object Object]":
      return Some(Object(mapObject(a, (key, value) => [key, makeJson(value)])));
    case "[object Array]":
      return Some(Array(a.map(makeJson)));
    case "[object Number]":
      return Some(Number(a));
    case "[object String]":
      return Some(String(a));
    case "[object Boolean]":
      return Some(Boolean(a));
    case "[object Null]":
      return Some(Null);
    default:
      return None;
    }
  };

  return (input) => {
    try {
      return makeJson(JSON.parse(input));

    // TODO maybe return the error message ?
    } catch (e) {
      return None;
    }
  };
};