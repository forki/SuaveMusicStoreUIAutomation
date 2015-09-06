module canopyExtensions

open canopy
open configuration
open types

let goto = canopy.core.url

let fastTextFromCSS selector =
  let script =
    //there is no map on NodeList which is the type returned by querySelectorAll =(
    sprintf """return [].map.call(document.querySelectorAll("%s"), function (item) { return item.text || item.innerText; });""" selector
  try
    js script :?> System.Collections.ObjectModel.ReadOnlyCollection<System.Object>
    |> Seq.map (fun item -> item.ToString())
    |> List.ofSeq
  with | _ -> [ "default" ]

let fastTextFromXPath selector =
  let script = sprintf """
    var results = [];
    var elements = document.evaluate("%s", document, null, XPathResult.ORDERED_NODE_ITERATOR_TYPE, null);
    var thisNode = elements.iterateNext();
    while (thisNode) {
      results.push(thisNode.textContent.trim());
      thisNode = elements.iterateNext();
    }
    return results;""" selector
  try
    js script :?> System.Collections.ObjectModel.ReadOnlyCollection<System.Object>
    |> Seq.map (fun item -> item.ToString())
    |> List.ofSeq
  with | _ -> [ "default" ]

let ( *=* ) selector list =
  let cleanAndFilter words =
    words
    |> List.filter (fun s -> s <> "" )
    |> List.map (fun s -> s.Replace(" ", "").Trim())

  let cssOrXPath () =
    let cssResults = fastTextFromCSS selector |> cleanAndFilter
    let xpathResults = fastTextFromXPath selector |> cleanAndFilter
    if xpathResults <> [ "default" ] then xpathResults
    else cssResults

  try
    waitFor (fun _ ->
      let cssResults = fastTextFromCSS selector |> cleanAndFilter
      let xpathResults = fastTextFromXPath selector |> cleanAndFilter
      cssResults = list || xpathResults = list)
  with
    | :? CanopyWaitForException ->
      raise (CanopyWaitForException(sprintf "waitFor list comparison failed in %.1f seconds%sGot: %A%sExpected: %A" compareTimeout System.Environment.NewLine (cssOrXPath()) System.Environment.NewLine list))
