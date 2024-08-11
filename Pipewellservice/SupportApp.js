var PWSSupportApp = PWSSupportApp || (
    function () {
        var jquery, _wid, _did;
        var w;
        const base = 'http://localhost:65199/'
       
        

        return {
            
            init: function (id) {
                _wid = id;
                w = this;
                /******** Load jQuery if not present *********/
                if (window.jQuery === undefined || window.jQuery.fn.jQuery !== '3.7.1') {
                    var script_tag = document.createElement('script');
                    script_tag.setAttribute("type", "text/javascript");
                    script_tag.setAttribute("src", "/Scripts/jQuery-3.7.1.js");
                    if (script_tag.readyState) {
                        script_tag.onreadystatechange = function () { // For old versions of IE
                            if (this.readyState == 'complete' || this.readyState == 'loaded') {
                                this.scriptLoadHandler();
                            }
                        };
                    } else {
                        script_tag.onload = this.scriptLoadHandler;
                    }
                    // Try to find the head, otherwise default to the documentElement
                    (document.getElementsByTagName("head")[0] || document.documentElement).appendChild(script_tag);
                } else {
                    // The jQuery version on the window is the one we want to use
                    jquery = window.jQuery;
                    this.scriptLoadHandler();
                }
            },
            scriptLoadHandler: function () {
                jquery = window.jQuery.noConflict(true);
                PWSSupportApp.render();
            },
            render: function () {

                jquery(document).ready(function (jquery) {
                    w.createHandler();

                });
            },
            createHandler: function () {
                var d = w.createElement('<div>', "pws-app-" + _wid, "pws-text-container pws-d-none", null, null, null);
                jquery(d).append(w.chatContainer());
                ///
                var p = w.createElement('<div>', "pws-prompt", "pws-prompt", 'click', function (e) { if (jquery(e.target).hasClass("close")) { jquery("#pws-prompt").hide(); window.localStorage.setItem("hideprompt", 0) } else { w.toogleChat(jquery("#pws-btn-chat")); } }, '<div class="pws-promptText" id="pws-promptText"><div class="pws-prompt-text"id="pws-prompt-text">Hi there, have a problem tell us here.</div><div><button type="button" class="close pws-d-none">×</button></div></div>');
                jquery(d).append(p);
                var b = w.createElement('<div>', "pws-app-btn-" + _wid, "pws-btn-container", null, null, null);
                jquery(b).append(w.createElement("<button>", 'pws-btn-chat', "pws-btn pws-btn-success pws-btn-circle pws-text-center", 'click', function () { w.toogleChat(this); }, w.Options.icon));
               // if (window.localStorage.getItem("hideprompt") && window.localStorage.getItem("hideprompt") == 1) {
                //    jquery(d).find("#pws-prompt").hide();
              //  }
                
                jquery(d).append(b);
                w.InitTextBody()
                jquery("body").append(d);

            },
            createElement: function (t, i, s, h, c, ic) {
                var e = jquery(t);
                jquery(e).attr("id", i).addClass(s);
                c != null ? jquery(e).on(h, c) : "";
                ic != null ? jquery(e).append(ic) : "";
                return e;
            },
            chatContainer: function () {
                var c = w.createElement('<div>', 'pws-chat-container', "pws-chat-container pws-d-none", null, null, null)
                
                return c;
            },
            Options: {
                icon: '<i class="fa fa-paper-plane fa-1x pws-text-white fa-rotate-icon"></i>'
            },
            toogleChat: function (i) {
                
                jquery(i).toggleClass("open");
                w.toggleIcon(i);
                
                jquery("#txtReportingName").val(!User ? "" : User.Name);
                jquery("#txtReportingIssue").val("");
                jquery("#pws-prompt").toggleClass("pws-d-none");
                jquery(".pws-chat-container").toggleClass("pws-d-none");
                
                
                jquery("#pws-chat-body-inner").find(".pws-form-control").each(function () {
                    jquery(this).val('');
                })

            },
            p: false,
            d: false,
            toggleIcon: function (i) {
                var ico = jquery(i).find("i.fa")[0];
                jquery(ico).toggleClass("fa-paper-plane");
                jquery(ico).toggleClass("fa-times")
            },
            InitTextBody: function () {
                jquery(".spinner").show();
                jquery.ajax({
                    type: "Post",
                    url: base + "/Support",
                    data: {
                        WidgetCode: _wid,
                        hostname: location.host
                    },
                    success: function (data) {
                        
                        jquery("#pws-app-" + _wid).removeClass("pws-d-none");
                        jquery("#pws-chat-container").append(data);
                        jquery(".spinner").hide();
                        
                    },
                    error: function () {
                        jquery(".spinner").hide();

                        //jquery(".spinner").d-none();
                    },
                });
            },
            
            
       
            
            SendResponse: function () {
                jquery(".spinner").show();
                if (jquery("#txtReportingIssue").val() == "") {
                    swal("Please describe the issue you faced.", {icon:"error"})
                    return false;
                }
                var Report = {
                    Name: jquery("#txtReportingName").val(),
                    Problem: jquery("#txtReportingIssue").val(),
                    FileName:""
                }
                var fileData = new FormData();
                var Supportfile = $('#flReportingFile').get(0);
                var files = Supportfile.files;
                if (files.length > 0) {
                    fileData.append("File", files[0]);

                    if (files[0].size > 2000000) {
                        swal("Please upload file less than 2MB", { icon: "error" });
                        return false;
                    }
                    if (!(/\.(docx|doc|pdf|jpg|jpeg|png)$/i).test(files[0].name)) {
                        swal('Please select the file format. Only .pdf, .doc,.doc,jpg,jpeg or png  formats are supported.', { icon: "error" });
                        return false;
                    }
                    Report.FileName = files[0].name;
                }

                fileData.append("report", JSON.stringify(Report));

                jquery.ajax({
                    url: '/Support/Submit',
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: fileData,
                    success: function (Response) {
                        if (Response > 0) {
                            
                            PWSSupportApp.DataSuccess();

                        } else {
                            swal({ text: "Failed to save data, please try again.", icon: "error" });
                        }
                        $("#spinner").hide();

                    },
                    error: function (errormessage) {
                        $("#spinner").hide();
                        swal({ text: "Failed to save data, please try again.", icon: "error" });
                    }
                });

            }
            , DataSuccess: function (rid) {
                this.toogleChat();
                swal("Thank you for your support, we will contact you soon with update", { icon: "success" });
                jquery(".spinner").hide();
                
            },
            CleanID: function (id) {
                return id.replace(/[^a-zA-Z0-9]/g, '');
            }
        };

        if (typeof Object.assign !== 'function') {
            Object.defineProperty(Object, "assign", {
                value: function assign(target, varArgs) { // .length of function is 2
                    'use strict';
                    if (target === null || target === undefined) {
                        throw new TypeError('Cannot convert undefined or null to object');
                    }

                    var to = Object(target);

                    for (var index = 1; index < arguments.length; index++) {
                        var nextSource = arguments[index];

                        if (nextSource !== null && nextSource !== undefined) {
                            for (var nextKey in nextSource) {
                                // Avoid bugs when hasOwnProperty is shadowed
                                if (Object.prototype.hasOwnProperty.call(nextSource, nextKey)) {
                                    to[nextKey] = nextSource[nextKey];
                                }
                            }
                        }
                    }
                    return to;
                },
                writable: true,
                configurable: true
            });
        }

        if (!String.prototype.startsWith) {
            String.prototype.startsWith = function (searchString, position) {
                position = position || 0;
                return this.indexOf(searchString, position) === position;
            };
        }
    }()
);

window.addEventListener('load', (event) => {
    PWSSupportApp.init(this.dataid);
});
//PWSSupportApp.init("asdasd");