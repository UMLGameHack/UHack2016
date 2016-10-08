
//cube([60,30,30]);
//Bottom piece
union()
{
    cube([60,30,2.25]);
    translate([0,1.25,2.5])difference()
    {
    cube([60,27.25,4.5]);
    //central cutaway
    translate([-4,1.5,2.25])cube([68,24.25,5.1]); //change height to 6 and width to 3mm for subtract
    //change height to 5.5mm and width to 2.5mm for positive
    
    }
}




////MAIN BODY
/*
difference()
{   
    union()
    {
    cube([60, 30,30]);
    translate([0.5,5.5,29]) linear_extrude(height = 3) text("Bard", 20.5, "Blockt:style=Regular");
        
    
    }
    translate([5,5,5])
    {
        //inner hollow part
        difference()
        {
            cube([50,20,20]);
            //support tha roof
    translate([0,-14,24]) rotate([-45,0,0]) cube([58,20,35]);
            translate([0,25,5]) rotate([45,0,0]) cube([58,20,35]);
        }
    }
    //big hole
    translate([20,15,15]) rotate([0,90,0]) cylinder(60, d = 12, d=12);
    //lil baby hole
    translate([-20,15,15]) rotate([0,90,0]) cylinder(60, d = 4, d=4);
    
union()
{
    cube([60,30,2.5]);
    translate([-1,1,2.5])difference()
    {
    cube([65,28,5]);
    //central cutaway
    translate([-4,2,2.5])cube([68,24,5.1]); //change height to 6 and width to 3mm for subtract
    //change height to 5.5mm and width to 2.5mm for positive
    
    }
}
} */