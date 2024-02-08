(function () {
    // header
    var appName = document.getElementById("app_name");
    var appDescription = document.getElementById("app_description");

    appName.onclick = () => {
        highlightMenu();
        var page = document.getElementById("page");
        page.replaceChildren(appDescription);
    }
    // end header

    // menu
    var menu = document.getElementById("menu");
    menu.classList.add("jselement");
    menu.classList.add("menu");
    var pagemodel = window.pagemodel || [];
    var pageloaded = {};

    pagemodel.forEach(x => {
        var menuElement = document.createElement("div");
        menuElement.classList.add("jselement");
        menuElement.classList.add("menu-item");
        menuElement.textContent = x.name;
        menuElement.onclick = () => {
            loadPage(x.name, pageloaded);
            highlightMenu(menuElement);
        }
        menu.append(menuElement);
    });

    function loadPage(name, loaded) {
        if (loaded[name] === undefined) {
            var classes = pagemodel.find(x => x.name === name);
            if (classes === undefined) return;

            loaded[name] = [];
            classes.methods.forEach(x => {
                loaded[name].push(createMethodElement(x));
            });
        }

        var page = document.getElementById("page");
        page.replaceChildren(...loaded[name]);
    }

    function createMethodElement(methodData) {
        var methodElement = document.createElement("div");
        methodElement.classList.add("jselement");
        methodElement.classList.add("method");
        methodElement.textContent = methodData.name;

        var nameElement = document.createElement("div");
        nameElement.classList.add("jselement");
        nameElement.classList.add("method-name");
        nameElement.textContent = methodData.name;

        var descriptionElement = document.createElement("div");
        descriptionElement.classList.add("jselement");
        descriptionElement.classList.add("method-description");
        descriptionElement.textContent = methodData.description;

        methodElement.replaceChildren(nameElement, descriptionElement);
        return methodElement;
    }

    function highlightMenu(menuElement) {
        menu.childNodes.forEach(menuNode => {
            if (menuNode !== menuElement) {
                menuNode.classList.remove("menu-highlight");
            }
        })

        if (menuElement !== undefined) {
            menuElement.classList.add("menu-highlight");
        }
    }
    // end menu
})();