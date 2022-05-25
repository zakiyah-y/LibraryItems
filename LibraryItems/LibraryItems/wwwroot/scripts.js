function search_libitems(item) {
  var input, filter, ul, li, x, i, txtValue;
  input = document.getElementById("searchbar");

  filter = input.value.toUpperCase();
  console.log(input.value.toUpperCase()); //see if what we're typing is being converted to upper case
  ul = document.getElementById("libItemList");
  li = ul.getElementsByTagName("li");
  for (i = 0; i < li.length; i++) {
    //console.log('test loop')
    x = li[i].getElementsByTagName("p")[0];
    txtValue = x.textContent || x.innerText;

    if (txtValue.toUpperCase().indexOf(filter) > -1) {
      li[i].style.display = "";
    } else {
      li[i].style.display = "none";
    }
  }
}

function showAddItemForm() {
  console.log("try a click");
  var element = document.getElementsByClassName("arrow-right");

  //call the item to access an element by its index
  for (let i = 0; i < element.length; i += 1) {
    element.item(i).classList.toggle("hide");
    //hide the right arrow
  }

  var arrowDown = document.getElementsByClassName("arrow-down");

  for (let i = 0; i < arrowDown.length; i += 1) {
    arrowDown.item(i).classList.toggle("show");
  }

  var showForm = document.getElementsByClassName("add-item-form");
  for (let i = 0; i < showForm.length; i += 1) {
    showForm.item(i).classList.toggle("show");
  }
}

function showList() {
  var element2 = document.getElementsByClassName("arrow-right2");

  for (let i = 0; i < element2.length; i += 1) {
    element2.item(i).classList.toggle("hide");
  }

  var arrowDown2 = document.getElementsByClassName("arrow-down2");

  for (let i = 0; i < arrowDown2.length; i += 1) {
    arrowDown2.item(i).classList.toggle("show");
  }

  var showList = document.getElementsByClassName("item-list");
  for (let i = 0; i < showList.length; i += 1) {
    showList.item(i).classList.toggle("show");
  }
}

/****************************************************************************
 * Add a new item.
 *
 * 1) send an update to the DB
 * 2) if successful then add the item to the list
 ****************************************************************************/

function addNewLibItem(newItemValue) {
  // Get the value from the Input field in the FORM
  let libItemValue = document.getElementById("newLibItemName").value.trim();
  let libItemDescValue = document.getElementById("newLibItemDesc").value.trim();
  let libItemLengthValue = document
    .getElementById("newLibItemLengthOfBooking")
    .value.trim();
  let libItemLocValue = document
    .getElementById("newLibItemLocation")
    .value.trim();
  // Check that a value have added
  if (libItemValue === "") {
    alert("Please fill in all fields");
  } else {
    alert("Item has been added :)");
  }
  createLibItem(
    libItemValue,
    libItemDescValue,
    libItemLengthValue,
    libItemLocValue
  );
  //clear all the fields here
  document.getElementById("newLibItemName").value = "";
  document.getElementById("newLibItemDesc").value = "";
  document.getElementById("newLibItemLengthOfBooking").value = "";
  document.getElementById("newLibItemLocation").value = "";
}

/****************************************************************************
 * This function will add  a new  item to the UL element
 * Specifically this will add:
 *
 *
 * 1) add to DB
 * 2) if successful then add the item to the list
 *
 ****************************************************************************/
function addLibItemToDisplay(item) {
  //log to console to see what's inside item object
  //  console.log(item)
  let libItemNode = document.createElement("li");
  const itemName = document.createElement("p");
  let descriptionTextNode = document.createTextNode(item["name"]);
  libItemNode.appendChild(itemName);
  itemName.appendChild(descriptionTextNode);

  //create a p within the list so that i can style it
  const para = document.createElement("p");
  para.innerText = "CHECKED OUT FOR: ";
  libItemNode.appendChild(para);

  const days = document.createElement("p");

  let description2TextNode = document.createTextNode(
    item["lengthOfBooking"] + " DAYS"
  );
  libItemNode.appendChild(days);
  days.appendChild(description2TextNode);

  document.getElementById("libItemList").appendChild(libItemNode);

  let tickSpanNode = document.createElement("SPAN");
  let tickText = document.createTextNode("\u2705"); // \u2713 is unicode for the tick symbol
  tickSpanNode.appendChild(tickText);
  libItemNode.appendChild(tickSpanNode);
  tickSpanNode.className = "tickHidden";

  let closeSpanNode = document.createElement("SPAN");

  const closeText = document.createElement("img");
  closeText.src = "./images/delete_item.svg";
  closeSpanNode.appendChild(closeText);
  closeSpanNode.className = "close";
  libItemNode.appendChild(closeSpanNode);

  closeSpanNode.onclick = function (event) {
    // stopPropagation() tells the event not to propagate
    event.stopPropagation();

    if (confirm("Are you sure that you want to delete " + item.name + "?")) {
      deleteLibItem(item["id"]);

      // Remove the HTML list element that is holding this item
      libItemNode.remove();
    }
  };

  //if an item is ticked off, assumes the user no longer has the book and so length of booking is no longer needed
  libItemNode.onclick = function () {
    if (item["lengthOfBooking"] !== 0) {
      item["lengthOfBooking"] = 0;
    } else {
      item["lengthOfBooking"] = item.lengthOfBooking;
    }

    updateLibItem(item);

    // }

    libItemNode.classList.toggle("checked");
    tickSpanNode.classList.toggle("tickVisible");
  };
}

/****************************************************************************
 * CRUD functions calling the REST API
 ****************************************************************************/

function createLibItem(
  libItemName,
  libItemDescription,
  libLength,
  libLocation
) {
  // Create a new JSON object for the new item with the status of NEW
  // Since the id is generated by the microservice, we will use -1 as a dummy
  // If the POST is successful the microservice will store the new item in the database
  // and returns a JSON via the response with the generated id for the new item
  const newItem = {
    name: libItemName,
    description: libItemDescription,
    location: libLocation,
    lengthOfBooking: libLength,
  };
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(newItem),
  };
  fetch("http://localhost:5000/LibraryItem", requestOptions)
    // get the JSON content from the response
    .then((response) => {
      if (!response.ok) {
        alert("An error has occurred.  Unable to create the library item");
        throw response.status;
      } else return response.json();
    })

    // add the item to the UL element so that it will appear in the browser
    .then((item) => addLibItemToDisplay(item));
}

// Load the list - expecting an array of todo_items to be returned
function readLibItems() {
  fetch("http://localhost:5000/LibraryItem")
    // get the JSON content from the response
    .then((response) => {
      if (!response.ok) {
        alert("An error has occurred.  Unable to read the library list");
        throw response.status;
      } else return response.json();
    })
    // Add the items to the UL element so that it can be seen
    // As items is an array, use array.map function to through the array and add item to the UL element
    // for display
    .then((items) => items.map((item) => addLibItemToDisplay(item)));
}

function updateLibItem(item) {
  const requestOptions = {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item),
  };
  fetch("http://localhost:5000/LibraryItem/" + item.id, requestOptions).then(
    (response) => {
      if (!response.ok) {
        alert("An error has occurred.  Unable to UPDATE the library item");
        throw response.status;
      } else return response.json();
    }
  );
}

function deleteLibItem(libItemId) {
  fetch("http://localhost:5000/LibraryItem/" + libItemId, {
    method: "DELETE",
  }).then((response) => {
    if (!response.ok) {
      alert("An error has occurred.  Unable to DELETE the TODO item");
      throw response.status;
    } else return response.json();
  });
}
