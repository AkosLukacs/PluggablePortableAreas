PluggablePortableAreas
======================

A short demo about how to create pluggable portable areas using MVCContrib.
This is an answer to this StackOverflow question: http://stackoverflow.com/questions/11023748/dynamically-extending-features-of-an-application

MVC4 version is available here: https://github.com/AkosLukacs/PluggablePortableAreasMVC4

Structure of the solution:

##Core projects:

 * PluggablePortableAreas.Common - A common class library project that now contains messages used by all projects.
 * PluggablePortableAreas.Web - The hosting web application. Drop custom areas to it's bin folder.

##Custom areas:
 There are two custom portable areas. Each contains it's own PortableAreaRegistration file that is used for two purposes: 
 * To register the area, standard PortableArea registration stuff...
 * To send a RegisterAreaMessage to the hosting app so it can add the Area's link to the header without additional configuration.


The two areas are not directly referenced by the hosting Web project, the built portable area dll's are copied using the project's postbuild event:
 `copy "$(TargetDir)$(TargetName).*" "$(SolutionDir)$(SolutionName).Web\bin"`

Rem, or delete the postbuild commands, and delete the corresponding dll's from PluggablePortableAreas.Web\bin, and try it that way.