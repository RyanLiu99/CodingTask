
/* will be insert by SSIS package
insert into dbo.State (state_code, state_name) values
(1,'Alaska'),
(2,'Alabama'),
(3,'Arkansas'),
(4,'Arizona')
;

insert into dbo.Region ([region_code], [region_name],[stat_code]) values
(743, 'Anchorage, AK', 1),
(745, 'Fairbanks,, AK', 1),
(747, 'Juneau, AK', 1),
(606, 'Dothan, AL', 2)
;
*/


insert into dbo.optimization_goal (optimization_goal_id, optimization_goal) values
(1,'orders'),
(2,'units sold'),
(3,'net ROI');


insert into dbo.Channel (channel_code, channel_name) values
(1,'online'),
(2,'retailer'),
(3,'phone');

insert into dbo.Product (product_code, product_name) values
(1,'cell phone'),
(2,'tablet'),
(3,'watch'),
(4, 'laptop');