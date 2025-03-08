// Art by Tobias (@everyshape in Gamejolt)
// Script by ryi3r (@ryi3r in Gamejolt)
// Works on UTY 1.1

using UndertaleModLib.Models;

EnsureDataLoaded();

public UndertaleGameObject.EventAction NewEventAction()
{
    UndertaleGameObject.EventAction eventAction = new UndertaleGameObject.EventAction();
    eventAction.LibID = 1;
    eventAction.ID = 603;
    eventAction.Kind = 7;
    eventAction.UseRelative = false;
    eventAction.IsQuestion = false;
    eventAction.UseApplyTo = true;
    eventAction.ExeType = 2;
    eventAction.ActionName = new UndertaleString();
    Data.Strings.Add(eventAction.ActionName);
    eventAction.ActionName.Content = "";
    eventAction.ArgumentCount = 1;
    eventAction.Who = -1;
    eventAction.Relative = false;
    eventAction.IsNot = false;
    eventAction.UnknownAlwaysZero = 0;
    return eventAction;
}

public void ReplaceCode()
{
    string[] str = {
        "gml_Object_obj_flowey_battle_screen_glitch_wheel_Alarm_0",
        "gml_Object_obj_flowey_battle_screen_glitch_ending_Alarm_0",
        "gml_Object_obj_flowey_battle_screen_glitch_attack_switch_Alarm_0",
        "gml_Object_obj_flowey_battle_screen_glitch_Alarm_0",
        "gml_Object_obj_flashback_transition_glitch_Alarm_0",
        "gml_Object_obj_flowey_battle_screen_glitch_fight_Alarm_0"
    };
    foreach (var e in str) {
        ImportGMLString(e, @"
if live_call()
    return global.live_result;
obj_border.draw_surf = true; //application_surface_draw_enable(true);
instance_destroy();
        ");
    }
    ImportGMLString("gml_Object_obj_darkruins_01_rope_Alarm_1", @"
scr_cutscene_end();
obj_pl.image_alpha = 1;
game_restart();
instance_create(0, 0, obj_darkruins_01_resettext);
scr_initialize();
obj_border.draw_surf = true; //application_surface_draw_enable(true);
    ");
    ImportGMLString("gml_Object_obj_screen_shatter_effect_Create_0", @"
surf_screen_copy = surface_create(surface_get_width(application_surface), surface_get_height(application_surface));
surf_screen_noloop = false;
h_number = 10;
v_number = 10;
total_number = h_number * v_number;
h_width = 320 / h_number;
v_height = 240 / v_number;
timer = 100;
var v = 0;
var h = 0;

for (var i = 0; i < total_number; i++)
{
    piece_x[i] = h_width * h;
    piece_y[i] = v_height * v;
    piece_hsp[i] = random_range(-1, 1);
    piece_vsp[i] = -4;
    h += 1;
    
    if (h > (h_number - 1))
    {
        h = 0;
        v += 1;
    }
}

piece_grav = 0.5;
audio_play_sound(snd_glass_smashable_large_break, 1, 0);
    ");
    ImportGMLString("gml_Object_obj_screen_shatter_effect_Destroy_0", @"
surface_free(surf_screen_copy);
obj_border.draw_surf = true; //application_surface_draw_enable(true)
");
    ImportGMLString("gml_Object_obj_flowey_battle_screen_glitch_wheel_Draw_64", @"
if live_call()
    return global.live_result;
//display_set_gui_size(-1, -1);
obj_border.draw_surf = false; //application_surface_draw_enable(false);
var app_surf_height = surface_get_height(application_surface);
var app_surf_width = surface_get_width(application_surface);
var screen_parts = 20;
var part_height = (app_surf_height / screen_parts);
surface_set_target(obj_border.surf);
for (var i = 0; i < screen_parts; i++)
{
    var x_offset = irandom_range(-30, 30);
    draw_surface_part_ext(application_surface, 0, (i * part_height), app_surf_width, part_height, x_offset, (i * part_height), 1, 1, 16777215, 1);
}
surface_reset_target();
//display_set_gui_size(320, 240);
    ");
    ImportGMLString("gml_Object_obj_screenshake_player_Step_0", @"
var camera_height = camera_get_view_height(view_camera[0]);
var camera_width = camera_get_view_width(view_camera[0]);
var x_target = clamp(view_object_original.x - floor(camera_width / 2), 0, room_width);
var y_target = clamp(view_object_original.y - floor(camera_height / 2), 0, room_height);
camera_set_view_target(view_camera[0], -4);
camera_set_view_pos(view_camera[0], x_target + irandom_range(-intensity, intensity), y_target + irandom_range(-intensity, intensity));
    ");
    ImportGMLString("gml_Object_obj_flowey_battle_screen_glitch_ending_Draw_64", @"
if live_call()
    return global.live_result;
//display_set_gui_size(-1, -1)
obj_border.draw_surf = false; //application_surface_draw_enable(false);
var app_surf_height = surface_get_height(application_surface);
var app_surf_width = surface_get_width(application_surface);
var screen_parts = 8;
var part_height = (app_surf_height / screen_parts);
var part_width = (app_surf_width / screen_parts);
surface_set_target(obj_border.surf);
for (var i = 0; i < screen_parts; i++)
{
    for (var j = 0; j < screen_parts; j++)
        draw_surface_part_ext(application_surface, (j * part_width), (i * part_height), part_width, part_height, (j * part_width), (i * part_height), random_range(0.5, 1.5), random_range(0.5, 1.5), 16777215, 1);
}
screen_parts = 6;
for (i = 0; i < screen_parts; i++)
{
    for (j = 0; j < screen_parts; j++)
        draw_surface_part_ext(application_surface, irandom_range(0, 320), irandom_range(0, 240), irandom_range(0, 320), irandom_range(0, 240), irandom_range(0, 640), irandom_range(0, 480), 1, 1, 16777215, 1);
}
surface_reset_target();
//display_set_gui_size(320, 240);
draw_set_alpha(noise_alpha);
draw_sprite_tiled(spr_flowey_battle_noise, 0, 0, 0);
draw_set_alpha(1);
    ");
    ImportGMLString("gml_Object_obj_flowey_battle_screen_glitch_attack_switch_Draw_64", @"
if live_call()
    return global.live_result;
//display_set_gui_size(-1, -1);
obj_border.draw_surf = false; //application_surface_draw_enable(false);
var app_surf_height = surface_get_height(application_surface);
var app_surf_width = surface_get_width(application_surface);
var screen_parts = 8;
var part_height = (app_surf_height / screen_parts);
var part_width = (app_surf_width / screen_parts);
surface_set_target(obj_border.surf);
for (var i = 0; i < screen_parts; i++)
{
    for (var j = 0; j < screen_parts; j++)
        draw_surface_part_ext(application_surface, (j * part_width), (i * part_height), part_width, part_height, (j * part_width), (i * part_height), random_range(0.5, 1.5), random_range(0.5, 1.5), 16777215, 1);
}
surface_reset_target();
//display_set_gui_size(320, 240);
    ");
    ImportGMLString("gml_Object_obj_flowey_battle_screen_glitch_Draw_64", @"
if live_call()
    return global.live_result;
//display_set_gui_size(-1, -1);
obj_border.draw_surf = false; //application_surface_draw_enable(false);
var app_surf_height = surface_get_height(application_surface);
var app_surf_width = surface_get_width(application_surface);
var screen_parts = 20;
var part_height = (app_surf_height / screen_parts);
surface_set_target(obj_border.surf);
for (var i = 0; i < screen_parts; i++)
{
    var x_offset = irandom_range(-50, 50);
    draw_surface_part_ext(application_surface, 0, (i * part_height), app_surf_width, part_height, x_offset, (i * part_height), 1, 1, 16777215, 1);
}
surface_reset_target();
//display_set_gui_size(320, 240);
    ");
    ImportGMLString("gml_Object_obj_flashback_transition_glitch_Draw_64", @"
if live_call()
    return global.live_result;
//display_set_gui_size(-1, -1);
obj_border.draw_surf = false; //application_surface_draw_enable(false);
var app_surf_height = surface_get_height(application_surface);
var app_surf_width = surface_get_width(application_surface);
var screen_parts = 20;
var part_height = (app_surf_height / screen_parts);
surface_set_target(obj_border.surf);
for (var i = 0; i < screen_parts; i++)
{
    var x_offset = irandom_range(-50, 50);
    draw_surface_part_ext(application_surface, 0, (i * part_height), app_surf_width, part_height, x_offset, (i * part_height), 1, 1, 16777215, 1);
}
surface_reset_target();
//display_set_gui_size(320, 240);
    ");
    ImportGMLString("gml_Object_obj_darkruins_01_rope_Draw_64", @"
if (waiter == 4)
{
    //display_set_gui_size(-1, -1);
    obj_border.draw_surf = false; //application_surface_draw_enable(false);
    var app_surf_height = surface_get_height(application_surface);
    var app_surf_width = surface_get_width(application_surface);
    surface_set_target(obj_border.surf);
    draw_surface_part_ext(application_surface, 0, 0, app_surf_width, (app_surf_height * 0.5), 20, 0, 1, 1, 16777215, 1);
    draw_surface_part_ext(application_surface, 0, (app_surf_height * 0.5), app_surf_width, app_surf_height, -20, (app_surf_height * 0.5), 1, 1, 16777215, 1);
    surface_reset_target();
    draw_sprite_ext(spr_flowey, 0, flowey_x, flowey_y, 2, 2, 0, c_white, 1);
    //display_set_gui_size(320, 240);
}
    ");
    ImportGMLString("gml_Object_obj_screen_shatter_effect_Draw_64", @"
if (live_call())
    return global.live_result;

if (surf_screen_noloop == 0)
{
    if (!surface_exists(surf_screen_copy))
        surf_screen_copy = surface_create(surface_get_width(application_surface), surface_get_height(application_surface));
    
    surface_set_target(surf_screen_copy);
    draw_clear_alpha(c_black, 0);
    surface_reset_target();
    surface_copy(surf_screen_copy, 0, 0, application_surface);
    obj_border.draw_surf = 0;
    surf_screen_noloop = 1;
}
else if (!surface_exists(surf_screen_copy))
{
    surf_screen_noloop = 0;
    exit;
}

var w_scale = surface_get_width(application_surface) / 320;
var h_scale = surface_get_height(application_surface) / 240;
var w_multiplier = 320 / surface_get_width(application_surface);
var h_multiplier = 240 / surface_get_height(application_surface);
var v = 0;
var h = 0;
var rs = 6;
surface_set_target(obj_border.surf);

for (var i = 0; i < total_number; i++)
{
    draw_surface_part_ext(surf_screen_copy, h * (h_width * w_scale), v * (v_height * h_scale), h_width * w_scale, v_height * h_scale, piece_x[i] * rs, piece_y[i] * rs, w_multiplier * rs, h_multiplier * rs, 16777215, 1);
    h += 1;
    
    if (h > (h_number - 1))
    {
        h = 0;
        v += 1;
    }
}

surface_reset_target();
    ");
    ImportGMLString("gml_Object_obj_flowey_battle_screen_glitch_fight_Draw_64", @"
if live_call()
    return global.live_result;
//display_set_gui_size(-1, -1);
obj_border.draw_surf = false; //application_surface_draw_enable(false);
var app_surf_height = surface_get_height(application_surface);
var app_surf_width = surface_get_width(application_surface);
var screen_parts = 20;
var part_height = (app_surf_height / screen_parts);
surface_set_target(obj_border.surf);
for (var i = 0; i < screen_parts; i++)
{
    var x_offset = irandom_range(-30, 30);
    draw_surface_part_ext(application_surface, 0, (i * part_height), app_surf_width, part_height, x_offset, (i * part_height), 1, 1, 16777215, 1);
}
surface_reset_target();
//display_set_gui_size(320, 240);
    ");
    ImportGMLString("gml_Object_obj_robot_build_item_Draw_75", @"
draw_set_alpha(obj_robot_build_controller.draw_alpha);
image_xscale /= 2;
image_yscale /= 2;
x /= 2;
y /= 2;
draw_self();
x *= 2;
y *= 2;
image_xscale *= 2;
image_yscale *= 2;
draw_set_alpha(1);
    ");
    ImportGMLString("gml_Object_obj_robot_build_cursor_Draw_75", @"
if instance_exists(obj_border)
    display_set_gui_maximise((obj_border.SF * obj_border.SRF) / 2, (obj_border.SF * obj_border.SRF) / 2, obj_border.pos_x, obj_border.pos_y);
else
    display_set_gui_size(640, 480);
draw_self();
if instance_exists(obj_border)
    display_set_gui_maximise(obj_border.SF * obj_border.SRF, obj_border.SF * obj_border.SRF, obj_border.pos_x, obj_border.pos_y);
else
    display_set_gui_size(320, 240);
    ");
    ImportGMLString("gml_Object_obj_robot_build_controller_Draw_64", @"
if (instance_exists(obj_border))
    display_set_gui_maximise((obj_border.SF * obj_border.SRF) / 2, (obj_border.SF * obj_border.SRF) / 2, obj_border.pos_x, obj_border.pos_y);
else
    display_set_gui_size(640, 480);

draw_set_alpha(draw_alpha);
draw_set_color(c_black);
draw_rectangle(0, 0, 640, 480, 0);
var robot_box_xx = 60;
var robot_box_yy = 20;
var robot_box_width = robot_box_xx + 220;
var robot_box_height = robot_box_yy + 260;
draw_set_color(c_white);
draw_rectangle(robot_box_xx - 4, robot_box_yy - 4, robot_box_width + 4, robot_box_height + 4, 0);
draw_set_color(c_black);
draw_rectangle(robot_box_xx, robot_box_yy, robot_box_width, robot_box_height, 0);
draw_set_color(c_green);
draw_rectangle(robot_box_xx + 20, robot_box_yy + 20, robot_box_width - 20, robot_box_height - 20, 1);
draw_line(robot_box_xx + 20 + 90, robot_box_yy + 20, robot_box_xx + 20 + 90, robot_box_height - 20);
draw_line(robot_box_xx + 20, robot_box_yy + 20 + 110, robot_box_width - 20, robot_box_yy + 20 + 110);
var box_select_xx = 580;
var box_select_yy = 20;
var box_select_width = box_select_xx - 220;
var box_select_height = box_select_yy + 260;
draw_set_color(c_white);
draw_rectangle(box_select_xx + 4, box_select_yy - 4, box_select_width - 4, box_select_height + 4, 0);
draw_set_color(c_dkgray);
draw_rectangle(box_select_xx, box_select_yy, box_select_width, box_select_height, 0);

if (!global.dialogue_open)
{
    var dbox_xx = 60;
    var dbox_yy = 320;
    var dbox_width = dbox_xx + 420;
    var dbox_height = dbox_yy + 128;
    draw_set_color(c_white);
    draw_rectangle(dbox_xx - 4, dbox_yy - 4, dbox_width + 4, dbox_height + 4, 0);
    draw_set_color(c_black);
    draw_rectangle(dbox_xx, dbox_yy, dbox_width, dbox_height, 0);
    draw_set_color(c_white);
    draw_set_font(fnt_main_battle);
    draw_text(80, 330, string_hash_to_newline(string(global.action_key) + " - Seleccionar/Colocar#" + string(global.pause_key) + " - Cancelar Selección#" + string(global.cancel_key) + " - Rotar/Agrandar"));
    var butt1_xx = 500;
    var butt1_yy = 320;
    var butt1_width = butt1_xx + 80;
    var butt1_height = butt1_yy + 50;
    var butt1_color = 16777215;
    
    if (gui_button_selected == 0)
        butt1_color = 65535;
    
    draw_set_color(butt1_color);
    draw_rectangle(butt1_xx - 4, butt1_yy - 4, butt1_width + 4, butt1_height + 4, 0);
    draw_set_color(c_black);
    draw_rectangle(butt1_xx, butt1_yy, butt1_width, butt1_height, 0);
    draw_set_font(fnt_mainb);
    draw_set_color(butt1_color);
    draw_text(butt1_xx + 10, butt1_yy + 7, string_hash_to_newline("ELIM"));
    var butt2_xx = 500;
    var butt2_yy = 398;
    var butt2_width = butt2_xx + 80;
    var butt2_height = butt2_yy + 50;
    var butt2_color = 16777215;
    
    if (gui_button_selected == 1)
        butt2_color = 65535;
    
    draw_set_color(butt2_color);
    draw_rectangle(butt2_xx - 4, butt2_yy - 4, butt2_width + 4, butt2_height + 4, 0);
    draw_set_color(c_black);
    draw_rectangle(butt2_xx, butt2_yy, butt2_width, butt2_height, 0);
    draw_set_font(fnt_mainb);
    draw_set_color(butt2_color);
    draw_text(butt2_xx + 10, butt2_yy + 7, string_hash_to_newline("YA"));
}

var robot_item_number = instance_number(obj_robot_build_item);
draw_set_color(c_white);

if (robot_item_number >= item_number_max)
    draw_set_color(c_red);

draw_set_font(fnt_mainb);
draw_set_halign(fa_center);
draw_text(320, 280, string_hash_to_newline(string(robot_item_number) + " / " + string(item_number_max)));
draw_set_halign(fa_left);
draw_set_color(c_white);
draw_sprite_ext(robot_item[0], 0, 415, 85, robot_item_scale[0], robot_item_scale[0], 0, c_white, draw_alpha);
draw_sprite_ext(robot_item[1], 0, 525, 85, robot_item_scale[1], robot_item_scale[1], 0, c_white, draw_alpha);
draw_sprite_ext(robot_item[2], 0, 415, 225, robot_item_scale[2], robot_item_scale[2], 0, c_white, draw_alpha);
draw_sprite_ext(robot_item[3], 0, 525, 225, robot_item_scale[3], robot_item_scale[3], 0, c_white, draw_alpha);
draw_set_alpha(1);

if (instance_exists(obj_border))
    display_set_gui_maximise(obj_border.SF * obj_border.SRF, obj_border.SF * obj_border.SRF, obj_border.pos_x, obj_border.pos_y);
else
    display_set_gui_size(320, 240);
    ");
}

public void AddCode()
{
    ImportGMLString("gml_Object_obj_border_Create_0", @"
ini_open(@'Controls.sav');
enabled = ini_read_real(@'Border', @'enabled', false);
ini_close();
SW = (window_get_fullscreen() ? display_get_width() : window_get_width());
SH = (window_get_fullscreen() ? display_get_height() : window_get_height());
SX = (enabled ? (SW / 960) : (SW / 640));
SY = (enabled ? (SH / 540) : (SH / 480));
SF = min(SX, SY);
SC = min(SW, SH);
SRW = surface_get_width(application_surface) / 960;
SRH = surface_get_height(application_surface) / 540;
SRF = min(SRW, SRH);
sprite = noone;
sprite_previous = noone;
alpha = 1.0;
play_animation = false;
animation_frames = 30 * (3 / 4);
animation_current_frame = 0;
trigger_change = true;
swap_enabled = false;
pos_x = 0.0;
pos_y = 0.0;
scale_x = 1.0;
scale_y = 1.0;
draw_surf = true;
surf = surface_create(256, 256);
sprite_prefetch_multi([
    spr_border_anime,
    spr_border_castle,
    spr_border_dog,
    spr_border_fire,
    spr_border_line,
    spr_border_rad,
    spr_border_ruins,
    spr_border_sepia,
    spr_border_sepia_glow,
    spr_border_truelab,
    spr_border_tundra,
    spr_border_water,
    spr_border_dunes,
    spr_border_steamworks,
    spr_border_mines,
    spr_border_dark_ruins,
    spr_border_empty,
    spr_border_flowey,
    spr_border_final_martlet,
    spr_border_final_ceroba,
    spr_border_geno_ceroba,
    spr_border_axis,
    spr_border_feisty_four,
    spr_border_casino,
]); // preload all borders so that there's no lag spikes, tho this requires 1.5gb of free ram at most
    ");
    ImportGMLString("gml_Object_obj_border_CleanUp_0", @"
if surface_exists(surf) && surf != application_surface {
    surface_free(surf);
}
    ");
    ImportGMLString("gml_Object_obj_border_Other_4", @"
event_user(0);
    ");
    ImportGMLString("gml_Object_obj_border_Step_0", @"
SW = (window_get_fullscreen() ? display_get_width() : window_get_width());
SH = (window_get_fullscreen() ? display_get_height() : window_get_height());
SX = (enabled ? (SW / 960) : (SW / 640));
SY = (enabled ? (SH / 540) : (SH / 480));
SF = min(SX, SY);
SC = min(SW, SH);
SRW = surface_get_width(application_surface) / 960;
SRH = surface_get_height(application_surface) / 540;
SRF = min(SRW, SRH);
event_user(0);
if play_animation {
    alpha = 1.0 - (animation_current_frame / animation_frames);
    animation_current_frame += 1;
    if animation_current_frame > animation_frames {
        play_animation = false;
        animation_current_frame = 0;
    }
}
if swap_enabled {
    swap_enabled = false;
    trigger_change = true;
    enabled = !enabled;
}
if trigger_change {
    trigger_change = false;
    if enabled {
        window_set_size(960, 540);
        event_user(0);
    } else {
        window_set_size(640, 480);
    }
    window_center();
}
    ");
    ImportGMLString("gml_Object_obj_border_Draw_77", @"
if surf == application_surface || !surface_exists(surf) { // Just accounting for some GameMaker shanenigans! :P
    surf = surface_create(256, 256);
}
if surface_get_width(surf) != surface_get_width(application_surface) || surface_get_height(surf) != surface_get_height(application_surface) {
    surface_resize(surf, surface_get_width(application_surface), surface_get_height(application_surface));
}
if keyboard_check_pressed(vk_f3) {
    enabled = !enabled;
    trigger_change = true;
    scr_savecontrols();
}
application_surface_draw_enable(false);
if enabled {
    pos_x = (160 * SF) + ((SW - ((1920 * ((1 / 2) / SRF)) * (SF * SRF))) / 2);
    pos_y = (30 * SF) + ((SH - ((1080 * ((1 / 2) / SRF)) * (SF * SRF))) / 2);
} else {
    pos_x = ((SW - ((1280 * ((1 / 2) / SRF)) * (SF * SRF))) / 2);
    pos_y = ((SH - ((960 * ((1 / 2) / SRF)) * (SF * SRF))) / 2);
}
display_set_gui_maximise(SF * SRF, SF * SRF, pos_x, pos_y);
scale_x = SF * (640 / surface_get_width(application_surface));
scale_y = SF * (480 / surface_get_height(application_surface));
gpu_set_blendenable(false);
// surf is the surface that's mainly used by effects
draw_surface_ext(draw_surf ? application_surface : surf, pos_x, pos_y, scale_x, scale_y, 0, c_white, 1.0);
gpu_set_blendenable(true);
surface_set_target(surf);
draw_clear_alpha(c_black, 0);
surface_reset_target();
    ");
    ImportGMLString("gml_Object_obj_border_Draw_75", @"
display_set_gui_maximise(SF * SRF, SF * SRF, (SW - ((sprite_get_width(spr_border_empty) * ((1 / 2) / SRF)) * (SF * SRF))) / 2, (SH - ((sprite_get_height(spr_border_empty) * ((1 / 2) / SRF)) * (SF * SRF))) / 2); // Hacky solution, but it works! :D
var __x = 0;
var __y = 0;
var __xs = (1 / 2) / SRF;
var __ys = (1 / 2) / SRF;
if enabled {
    var col = draw_get_color();
    var draw_alpha = draw_get_alpha();
    draw_set_color(c_black);
    draw_set_alpha(1);
    draw_rectangle(__x, __y, -1500, 1500, 0); // Top-left
    draw_rectangle(__x + (sprite_get_width(spr_border_empty) * __xs), __y, 1500, 1500, 0); // Top-right
    draw_rectangle(__x - 1500, __y, 3000, -1500, 0); // Top-center
    draw_rectangle(__x - 1500, __y + (sprite_get_height(spr_border_empty) * __ys), 3000, 1500, 0); // Bottom-center
    draw_set_color(col);
    draw_set_alpha(draw_alpha);
    if draw_surf {
        if sprite_exists(sprite) {
            draw_sprite_ext(sprite, 0, __x, __y, __xs, __ys, 0, c_white, 1.0);
        } else {
            draw_sprite_ext(spr_border_empty, 0, __x, __y, __xs, __ys, 0, c_white, 1.0);
        }
        if sprite_exists(sprite_previous) {
            draw_sprite_ext(sprite_previous, 0, __x, __y, __xs, __ys, 0, c_white, alpha);
        }
    } else {
        if sprite_exists(sprite) {
            draw_sprite_ext(sprite, 0, __x, __y, __xs, __ys, 0, c_white, 1.0);
        } else {
            draw_sprite_ext(spr_border_empty, 0, __x, __y, __xs, __ys, 0, c_white, 1.0);
        }
        if sprite_exists(sprite_previous) {
            draw_sprite_ext(sprite_previous, 0, __x, __y, __xs, __ys, 0, c_white, alpha);
        }
    }
} else {
    var col = draw_get_color();
    var draw_alpha = draw_get_alpha();
    draw_set_color(c_black);
    draw_set_alpha(1);
    draw_rectangle(__x + (160 / 2), __y + (30 / 2), -1500, 1500, 0); // Top-left
    draw_rectangle(__x + (160 / 2) + ((640 * 2) * __xs), __y + (30 / 2), 1500, 1500, 0); // Top-right
    draw_rectangle(__x + (160 / 2) - 1500, __y + (30 / 2), 3000, -1500, 0); // Top-center
    draw_rectangle(__x + (160 / 2) - 1500, __y + (30 / 2) + ((480 * 2) * __ys), 3000, 1500, 0); // Bottom-center
    draw_set_color(col);
    draw_set_alpha(draw_alpha);
}
    ");
    ImportGMLString("gml_Object_obj_border_Other_10", @"
var rn = room_get_name(room);
var nsprite = noone;
var set_no_border = false;

if string_starts_with(rn, @'rm_ruins') {
    nsprite = spr_border_ruins;
}
if string_starts_with(rn, @'rm_darkruins') || string_starts_with(rn, @'rm_dalv') {
    nsprite = spr_border_dark_ruins;
}
if string_starts_with(rn, @'rm_snowdin') {
    nsprite = spr_border_tundra;
}
if string_starts_with(rn, @'rm_waterfall') {
    nsprite = spr_border_water;
}
if string_starts_with(rn, @'rm_hotland') {
    nsprite = spr_border_fire;
}
if string_starts_with(rn, @'rm_dunes') || string_starts_with(rn, @'rm_mansion') {
    nsprite = spr_border_dunes;
    if instance_exists(obj_card_game_controller) {
        nsprite = spr_border_casino;
    }
}
if string_starts_with(rn, @'rm_newhome') || string_starts_with(rn, @'rm_castle') {
    nsprite = spr_border_castle;
}
if string_starts_with(rn, @'rm_steamworks') {
    nsprite = spr_border_steamworks;
}

if instance_exists(obj_battle_generator) {
    switch global.battle_enemy_name_1 {
        case @'ceroba':
            if global.route != 3 {
                if !instance_exists(obj_ceroba_body_pacifist_phase_1) {
                    nsprite = spr_border_final_ceroba;
                }
            } else {
                nsprite = spr_border_geno_ceroba;
            }
            break;
        case @'martlet':
            if !instance_exists(obj_martlet_g_body) && !instance_exists(obj_martlet_body) && !instance_exists(obj_martlet_final_body_intro) {
                nsprite = spr_border_final_martlet;
            }
            break;
        case @'axis':
            nsprite = spr_border_axis;
            break;
    }
}
if instance_exists(obj_enemy_controller_feisty_four) {
    nsprite = spr_border_feisty_four;
}

switch room {
    case rm_intro:
    case rm_logos:
    case rm_mmfirst:
    case rm_mainmenu:
    case rm_config:
    case rm_joystickconfig:
    case rm_menu_flowey:
    nsprite = spr_border_line;
    break;
    case rm_dunes_06b:
    case rm_dunes_12:
    case rm_dunes_12b:
    case rm_dunes_13:
    case rm_dunes_elevator:
    case rm_dunes_14:
    case rm_dunes_15:
    case rm_dunes_16:
    case rm_dunes_17:
    case rm_dunes_19:
    case rm_dunes_19B:
    case rm_dunes_20:
    case rm_dunes_21:
    case rm_dunes_22:
    case rm_dunes_23:
    nsprite = spr_border_mines;
    break;
    case rm_mew_mew:
    nsprite = spr_border_anime;
    break;
    case rm_steamworks_36:
    case rm_steamworks_37:
    case rm_steamworks_38:
    nsprite = spr_border_fire;
    break;
    case rm_flashback_01:
    nsprite = spr_border_ruins;
    break;
    case rm_flashback_02:
    case rm_flashback_03:
    nsprite = spr_border_line;
    break;
    case rm_battle_flashback_01:
    nsprite = spr_border_ruins;
    break;
    case rm_battle_flashback_02:
    nsprite = spr_border_dark_ruins;
    break;
    case rm_battle_flashback_03:
    nsprite = spr_border_water;
    break;
    case rm_battle_flashback_04:
    nsprite = spr_border_dunes;
    break;
    case rm_battle_flashback_05:
    nsprite = spr_border_fire;
    break;
    case rm_battle_flashback_06:
    nsprite = spr_border_steamworks;
    break;
    case rm_battle_flashback_final:
    nsprite = spr_border_line;
    if layer_get_visible(@'The_Ruins') {
        nsprite = spr_border_ruins;
    }
    if layer_get_visible(@'Dark_Ruins') {
        nsprite = spr_border_dark_ruins;
    }
    if layer_get_visible(@'Waterfall') {
        nsprite = spr_border_water;
    }
    if layer_get_visible(@'The_Dunes') {
        nsprite = spr_border_dunes;
    }
    if layer_get_visible(@'Hotland') {
        nsprite = spr_border_fire;
    }
    if layer_get_visible(@'The_Steamworks') {
        nsprite = spr_border_steamworks;
    }
    if layer_get_visible(@'New_Home') {
        nsprite = spr_border_castle;
    }
    if layer_get_visible(@'True_Lab') {
        nsprite = spr_border_truelab;
    }
    break;
    case rm_battle_flashback_final_2:
    nsprite = spr_border_line;
    break;
    case rm_battle_flashback_07:
    nsprite = spr_border_tundra;
    break;
    case rm_battle_flowey:
    case rm_battle_flowey_phase_2:
    nsprite = spr_border_flowey;
    break;
    case rm_mansion_study:
    nsprite = spr_border_truelab;
    break;
    case -1:
    break;
}

if (sprite_exists(nsprite) && nsprite != sprite) || set_no_border {
    sprite_previous = sprite;
    sprite = nsprite;
    alpha = 1.0;
    play_animation = true;
    animation_current_frame = 0;
}
    ");
}

public void AddCodeObj(string objName, uint eventSubtype, string codeName, string stringCode)
{
    ImportGMLString(codeName, stringCode);
    var obj = Data.GameObjects.ByName(objName);
    bool doAdd = true;
    foreach (var evp in obj.Events)
    {
        foreach (var ev in evp)
        {
            if (ev.EventSubtype == eventSubtype)
            {
                doAdd = false;
                var eventAction = NewEventAction();
                eventAction.CodeId = Data.Code.ByName(codeName);
                ev.Actions.Add(eventAction);
            }
        }
    }
    if (doAdd)
    {
        UndertaleGameObject.Event objEvent = new();
        objEvent.EventSubtype = eventSubtype;
        var eventAction = NewEventAction();
        eventAction.CodeId = Data.Code.ByName(codeName);
        objEvent.Actions.Add(eventAction);
        UndertalePointerList<UndertaleGameObject.Event> r = new();
        r.Add(objEvent);
        obj.Events.Add(r);
    }
}

string bordersPath = Path.Combine(Path.GetDirectoryName(ScriptPath), @"Borders\");

if (!Directory.Exists(bordersPath))
{
    throw new ScriptException("Border textures not found??");
}

int lastTextPage = Data.EmbeddedTextures.Count - 1;
int lastTextPageItem = Data.TexturePageItems.Count - 1;

void AssignBorderBackground(string name, string texName, ushort x, ushort y, ushort width, ushort height)
{
    if (Data.Sprites.ByName(name) != null)
        return;

    var path = bordersPath + texName;
    UndertaleEmbeddedTexture tex = new();
    tex.Name = new UndertaleString("Texture " + ++lastTextPage);
    tex.TextureData.TextureBlob = File.ReadAllBytes(path);
    Data.EmbeddedTextures.Add(tex);

    var spr = new UndertaleSprite();
    Data.Sprites.Add(spr);
    spr.Name = new UndertaleString();
    Data.Strings.Add(spr.Name);
    spr.Name.Content = name;
    spr.Width = (uint)width;
    spr.Height = (uint)height;
    spr.MarginRight = (int)(width - 1);
    spr.MarginBottom = (int)(height - 1);

    UndertaleTexturePageItem tpag = new UndertaleTexturePageItem();
    tpag.Name = new UndertaleString("PageItem " + ++lastTextPageItem);
    tpag.SourceX = x; tpag.SourceY = y; tpag.SourceWidth = width; tpag.SourceHeight = height;
    tpag.TargetX = 0; tpag.TargetY = 0; tpag.TargetWidth = width; tpag.TargetHeight = height;
    tpag.BoundingWidth = width; tpag.BoundingHeight = height;
    tpag.TexturePage = tex;
    Data.TexturePageItems.Add(tpag);

    var txtr = new UndertaleSprite.TextureEntry();
    txtr.Texture = tpag;
    spr.Textures.Add(txtr);
}

AssignBorderBackground("spr_border_anime", "bg_border_anime.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_castle", "bg_border_castle.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_dog", "bg_border_dog.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_fire", "bg_border_fire.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_line", "bg_border_line.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_rad", "bg_border_rad.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_ruins", "bg_border_ruins.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_sepia", "bg_border_sepia.png", 114, 38, 1920, 1080);
AssignBorderBackground("spr_border_sepia_glow", "bg_border_sepia.png", 2, 1470, 137, 132);
AssignBorderBackground("spr_border_truelab", "bg_border_truelab.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_tundra", "bg_border_tundra.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_water", "bg_border_water1.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_dunes", "bg_border_dunes.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_steamworks", "bg_border_steamworks.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_mines", "bg_border_mines.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_dark_ruins", "bg_border_dark_ruins.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_empty", "bg_border_empty.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_flowey", "bg_border_flowey.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_final_martlet", "bg_border_final_martlet.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_final_ceroba", "bg_border_final_ceroba.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_geno_ceroba", "bg_border_geno_ceroba.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_axis", "bg_border_axis.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_feisty_four", "bg_border_feisty_four.png", 0, 0, 1920, 1080);
AssignBorderBackground("spr_border_casino", "bg_border_casino.png", 0, 0, 1920, 1080);

bool addObj = true;

foreach (var obj in Data.GameObjects)
{
    if (obj.Name.Content == "obj_border")
    {
        addObj = false;
        break;
    }
}

if (addObj)
{
    UndertaleGameObject obj = new UndertaleGameObject();
    Data.GameObjects.Add(obj);
    obj.Name = new UndertaleString();
    Data.Strings.Add(obj.Name);
    obj.Name.Content = "obj_border";
    obj.Persistent = true;

    ReplaceCode();
    AddCode();

    UndertaleGameObject.Event objEvent = new();
    var eventAction = NewEventAction();

    eventAction.CodeId = Data.Code.ByName("gml_Object_obj_border_Create_0");
    objEvent.Actions.Add(eventAction);
    UndertalePointerList<UndertaleGameObject.Event> r = new();
    r.Add(objEvent);
    obj.Events.Add(r);

    objEvent = new();
    eventAction = NewEventAction();
    objEvent.EventSubtype = (uint)EventSubtypeStep.Step;

    eventAction.CodeId = Data.Code.ByName("gml_Object_obj_border_CleanUp_0");
    objEvent.Actions.Add(eventAction);
    r = new();
    r.Add(objEvent);
    obj.Events.Add(r);

    objEvent = new();
    eventAction = NewEventAction();
    objEvent.EventSubtype = (uint)EventSubtypeStep.Step;

    eventAction.CodeId = Data.Code.ByName("gml_Object_obj_border_Step_0");
    objEvent.Actions.Add(eventAction);
    r = new();
    r.Add(objEvent);
    obj.Events.Add(r);

    objEvent = new();
    eventAction = NewEventAction();
    objEvent.EventSubtype = (uint)EventSubtypeDraw.PostDraw;

    eventAction.CodeId = Data.Code.ByName("gml_Object_obj_border_Draw_77");
    objEvent.Actions.Add(eventAction);
    r = new();
    r.Add(objEvent);
    obj.Events.Add(r);

    objEvent = new();
    eventAction = NewEventAction();
    objEvent.EventSubtype = (uint)EventSubtypeDraw.DrawGUIEnd;

    eventAction.CodeId = Data.Code.ByName("gml_Object_obj_border_Draw_75");
    objEvent.Actions.Add(eventAction);
    r = new();
    r.Add(objEvent);
    obj.Events.Add(r);

    objEvent = new();
    eventAction = NewEventAction();
    objEvent.EventSubtype = (uint)EventSubtypeOther.User0;

    eventAction.CodeId = Data.Code.ByName("gml_Object_obj_border_Other_10");
    objEvent.Actions.Add(eventAction);
    r = new();
    r.Add(objEvent);
    obj.Events.Add(r);

    objEvent = new();
    objEvent.EventSubtype = (uint)EventSubtypeOther.RoomStart;
    eventAction = NewEventAction();
    eventAction.CodeId = Data.Code.ByName("gml_Object_obj_border_Other_4");
    objEvent.Actions.Add(eventAction);
    r = new();
    r.Add(objEvent);
    obj.Events.Add(r);

    ReplaceTextInGML("gml_Object_obj_arcade_mew_Alarm_1", @"instance_deactivate_all(true)", @"instance_deactivate_all(true); instance_activate_object(obj_border)", true);
    ReplaceTextInGML("gml_Object_obj_arcade_boss_Step_0", @"instance_deactivate_all(true)", @"instance_deactivate_all(true); instance_activate_object(obj_border)", true);
    Data.Code.ByName("gml_Object_obj_controller_Create_0").AppendGML(@"layer_force_draw_depth(true, -15998); instance_create_depth(0, 0, -15998, obj_border);", Data);
    Data.Code.ByName("gml_Object_obj_config_Create_0").AppendGML(@"position_max += 1;", Data);
    Data.Code.ByName("gml_Object_obj_config_Step_0").AppendGML(@"
if instance_exists(obj_border) && keyboard_multicheck_pressed(0) && position == position_max {
    obj_border.enabled = (!obj_border.enabled);
    obj_border.trigger_change = 1;
    scr_savecontrols();
}
    ", Data);
    Data.Code.ByName("gml_Object_obj_config_Draw_0").AppendGML(@"
draw_set_color(c_white);
if position == position_max
    draw_set_color(c_yellow); // SOY EL UNDERTALE YELLOW
draw_text((__view_get((0 << 0), 0) + 20), (__view_get((1 << 0), 0) + 220), string_hash_to_newline(@'Enable Borders (F3)'));
draw_set_color(c_white);
if instance_exists(obj_border) && obj_border.enabled
    option = @'ON';
else
    option = @'OFF';
draw_text(((__view_get((0 << 0), 0) + 20) + 180), (__view_get((1 << 0), 0) + 220), string_hash_to_newline(option));
    ", Data);
}
else
{
    ReplaceCode();
    AddCode();
}

ScriptMessage(@"Succesfully imported borders!

Credits:
Art by Tobias (@everyshape in Gamejolt)
Script by ryi3r (@ryi3r in Gamejolt)");
