// init controller
var controller = new ScrollMagic.Controller();
    
// build scene
var scene = new ScrollMagic.Scene({triggerElement: ".dynamicContent #loader", triggerHook: "onEnter"})
                .addTo(controller)
                .on("enter", function (e) {
                    if (!$("#loader").hasClass("active")) {
                        $("#loader").addClass("active");
                        if (console){
                            console.log("loading new items");
                        }
                        // simulate ajax call to add content using the function below
                        setTimeout(addBoxes, 1000, 9);
                    }
                });

// pseudo function to add new content. In real life it would be done through an ajax request.
function addBoxes (amount) {
    for (i=1; i<=amount; i++) {
        var randomColor = '#'+('00000'+(Math.random()*0xFFFFFF<<0).toString(16)).slice(-6);
        $("<div></div>")
            .addClass("box1")
            .css("background-color", randomColor)
            .appendTo(".dynamicContent #content");
    }
    // "loading" done -> revert to normal state
    scene.update(); // make sure the scene gets the new start position
    $("#loader").removeClass("active");
}

// add some boxes to start with.
addBoxes(2);