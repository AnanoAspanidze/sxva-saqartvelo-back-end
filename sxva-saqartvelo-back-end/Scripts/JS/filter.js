let filterName = document.querySelectorAll('.filter-name');
for (const i of filterName) {
    i.addEventListener('click', (e) => {
        hideFilter(e);
    });
}

function hideFilter(e){
    if(e.srcElement.className === 'possibilities-headline' || $(e.path[0]).attr('id') === 'ps-up'){  
        $($('.possibilities-section').find('img')[0]).toggleClass('arrow-up')
        $('.possibilities').toggleClass('hide');
        $($('.possibilities-section').find('img')[0])
    }
    if(e.srcElement.className === 'rating-headline' || $(e.path[0]).attr('id') === 'rat-up'){
        $($('.rating-section').find('img')[0]).toggleClass('arrow-up');
        $('.rating-from-to').toggleClass('hide');
        $($('.rating-section').find('img')[0]);
    }
}

// checkbox
let checkbox = document.querySelectorAll('form label');
for (const i of checkbox) {
    i.addEventListener('click', (e) => {
        if($(e.path[0]).find('img')[0]){
            let checkboxStatus = $(e.path[0]).find('img')[0].className;
            if(checkboxStatus === 'checked-box'){
                $(e.path[0]).find('img')[0].className = 'checkbox';
            } else if(checkboxStatus === 'checkbox'){
                $(e.path[0]).find('img')[0].className = 'checked-box';
            } 
        } else if(($(e.path[0])[0]).className){
            let checkboxStatus = ($(e.path[0])[0]).className;
            if(checkboxStatus === 'checked-box'){
                ($(e.path[0])[0]).className = 'checkbox';
            } else if(checkboxStatus === 'checkbox'){
                ($(e.path[0])[0]).className = 'checked-box';
            } 
            
        };
    });
}

//bullets
// let bullets = document.querySelectorAll('.bullet-pagination');

// for (i = 0; i < bullets.length; i++) {
//     bullets[0].addEventListener('click', (e) => {
//         switchColors(e);        
//     });
// }

// switchColors = (e,clickedIndex) =>{
//     if($(e)[0].target.className === 'bullet'){
//         $(e)[0].target.className = 'active-bullet';
//         // for(i = 0; i < bullets.length; i++){
//         //     if(i !== clickedIndex){
//         //         console.log(bullets[0].querySelectorAll('span')[i].className);
//         //     }
//         // }
//     } else if($(e)[0].target.className === 'active-bullet'){
//         $(e)[0].target.className = 'bullet'
//     }
// }


// rating range=========================
     var test=0
     var test2=200
     console.log($('#line').offset().left)
     var b = function (e){
         var x=Math.round(e.clientX-$('#line').offset().left);
         var y=Math.round(e.clientX-$('#line').offset().left);
          var koepicienti=0.5;
          var nashti=100-koepicienti*x;
            if(x-test > test2-x){
          if (x*1>=0 && x<=200  ) {
            test2=x 
              document.getElementById('button2').style.right=-200-(x-15)+"px"
                document.getElementById('rating_hight').value=Math.round(100-nashti)
                document.getElementById('buutonaut2').style.width=200+$('#line').offset().left-e.clientX+"px"
              }

            }
            else {
         if (x*1>=0 && x<=200  ) {
            test=x
              document.getElementById('button1').style.left=(x-5)+"px"
              document.getElementById('rating_low').value=Math.round(100-nashti)
              document.getElementById('buutonaut').style.width=x+"px"
              };
            }
    }  

    document.getElementById('line').onmousedown=function(e){
                b(e);
                document.getElementById('line').onmousemove=b;
                document.getElementById('line').onmouseup=function(e){
                    document.getElementById('line').onmousemove = null;
                }
    }
    $('.clear-search').click(function(){
     
     console.log('test')

    })


// clear filter
let clearButton = document.getElementsByClassName('clear-search')[0];
let checkboxLength = $(document.getElementsByClassName('possibilities')[0]).find('img').length;

clearButton.addEventListener('click', (e) => {

    for(i = 0; i < checkboxLength; i++){
        $(document.getElementsByClassName('possibilities')[0]).find('img')[i].className = 'checkbox';
    }
    document.getElementById('buutonaut2').style.width=0+"px";
    document.getElementById('buutonaut').style.width=0+"px";
    document.getElementById('button1').style.left=-3+"px";
    
    document.getElementsByClassName('rating-from-to')[0][0].value = '0';
    document.getElementsByClassName('rating-from-to')[0][1].value = '100';
});